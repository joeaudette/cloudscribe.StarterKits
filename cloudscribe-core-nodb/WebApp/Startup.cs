using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
          
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public bool SslIsAvailable { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string pathToCryptoKeys = Path.Combine(environment.ContentRootPath, "dp_keys");
            services.AddDataProtection()
                // .PersistKeysToFileSystem(new System.IO.DirectoryInfo(pathToCryptoKeys))
                ;

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
            });

            services.AddMemoryCache();

            //services.AddSession();

            ConfigureAuthPolicy(services);

            services.AddOptions();

            services.AddCloudscribeCoreNoDbStorage();

            // only needed if using cloudscribe logging with EF storage
            services.AddCloudscribeLoggingNoDbStorage(Configuration);
            services.AddCloudscribeLogging();

            services.AddCloudscribeCoreMvc(Configuration);

            // optional but recommended if you need localization 
            // uncomment to use cloudscribe.Web.localization https://github.com/joeaudette/cloudscribe.Web.Localization
            //services.Configure<GlobalResourceOptions>(Configuration.GetSection("GlobalResourceOptions"));
            //services.AddSingleton<IStringLocalizerFactory, GlobalResourceManagerStringLocalizerFactory>();

            services.AddLocalization(options => options.ResourcesPath = "GlobalResources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("en-GB"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("fr"),
                };

                // State what the default culture for your application is. This will be used if no specific culture
                // can be determined for a given request.
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

                // You must explicitly state which cultures your application supports.
                // These are the cultures the app supports for formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;

                // These are the cultures the app supports for UI strings, i.e. we have localized resources for.
                options.SupportedUICultures = supportedCultures;

                // You can change which providers are configured to determine the culture for requests, or even add a custom
                // provider with your own logic. The providers will be asked in order to provide a culture for each request,
                // and the first to provide a non-null result that is in the configured supported cultures list will be used.
                // By default, the following built-in providers are configured:
                // - QueryStringRequestCultureProvider, sets culture via "culture" and "ui-culture" query string values, useful for testing
                // - CookieRequestCultureProvider, sets culture via "ASPNET_CULTURE" cookie
                // - AcceptLanguageHeaderRequestCultureProvider, sets culture via the "Accept-Language" request header
                //options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
                //{
                //  // My custom request culture logic
                //  return new ProviderCultureResult("en");
                //}));
            });

            SslIsAvailable = Configuration.GetValue<bool>("AppSettings:UseSsl");
            services.Configure<MvcOptions>(options =>
            {
                if (SslIsAvailable)
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                }
            });

            // it is recommended to use lower case urls
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            services.AddMvc()
                .AddRazorOptions(options =>
                {
                    options.AddCloudscribeViewLocationFormats();
                    options.AddCloudscribeCommonEmbeddedViews();
                    options.AddCloudscribeNavigationBootstrap3Views();
                    options.AddCloudscribeCoreBootstrap3Views();
                    options.AddCloudscribeFileManagerBootstrap3Views();
                    options.AddCloudscribeLoggingBootstrap3Views();

                    options.ViewLocationExpanders.Add(new cloudscribe.Core.Web.Components.SiteViewLocationExpander());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IOptions<cloudscribe.Core.Models.MultiTenantOptions> multiTenantOptionsAccessor,
            IOptions<RequestLocalizationOptions> localizationOptionsAccessor
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/oops/Error");
            }

            app.UseForwardedHeaders();
            app.UseStaticFiles();

            app.UseRequestLocalization(localizationOptionsAccessor.Value);

            var multiTenantOptions = multiTenantOptionsAccessor.Value;

            app.UseCloudscribeCore(
                    loggerFactory,
                    multiTenantOptions,
                    SslIsAvailable);

            UseMvc(app, multiTenantOptions.Mode == cloudscribe.Core.Models.MultiTenantMode.FolderName);
            
        }

        private void UseMvc(IApplicationBuilder app, bool useFolders)
        {
            app.UseMvc(routes =>
            {
                routes.AddCloudscribeFileManagerRoutes();

                if (useFolders)
                {
                    routes.MapRoute(
                       name: "foldererrorhandler",
                       template: "{sitefolder}/oops/error/{statusCode?}",
                       defaults: new { controller = "Oops", action = "Error" },
                       constraints: new { name = new cloudscribe.Core.Web.Components.SiteFolderRouteConstraint() }
                    );

                    routes.MapRoute(
                        name: "folderdefault",
                        template: "{sitefolder}/{controller}/{action}/{id?}",
                        defaults: new { controller = "Home", action = "Index" },
                        constraints: new { name = new cloudscribe.Core.Web.Components.SiteFolderRouteConstraint() }
                        );

                }

                routes.MapRoute(
                    name: "errorhandler",
                    template: "oops/error/{statusCode?}",
                    defaults: new { controller = "Oops", action = "Error" }
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );



            });
        }

        private void ConfigureAuthPolicy(IServiceCollection services)
        {
            //https://docs.asp.net/en/latest/security/authorization/policies.html

            services.AddAuthorization(options =>
            {
                options.AddCloudscribeCoreDefaultPolicies();
                options.AddCloudscribeLoggingDefaultPolicy();

                options.AddPolicy(
                    "FileManagerPolicy",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Administrators", "Content Administrators");
                    });

                options.AddPolicy(
                    "FileManagerDeletePolicy",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Administrators", "Content Administrators");
                    });

                // add other policies here 

            });

        }

       
    }
}