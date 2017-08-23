using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApp.Integration
{
    public class SiteCookieAuthenticationOptions : IOptionsSnapshot<CookieAuthenticationOptions>
    {
        public SiteCookieAuthenticationOptions(
            IPostConfigureOptions<CookieAuthenticationOptions> cookieOptionsInitializer,
            IHttpContextAccessor httpContextAccessor,
            ILogger<SiteCookieAuthenticationOptions> logger
            )
        {
            _cookieOptionsInitializer = cookieOptionsInitializer;
            _httpContextAccessor = httpContextAccessor;
            _log = logger;
        }

        private IPostConfigureOptions<CookieAuthenticationOptions> _cookieOptionsInitializer;
        private IHttpContextAccessor _httpContextAccessor;
        private ILogger _log;

        private CookieAuthenticationOptions ResolveOptions(string scheme)
        {
            var tenant = _httpContextAccessor.HttpContext.GetTenant<SiteSettings>();

            var options = new CookieAuthenticationOptions();
            _cookieOptionsInitializer.PostConfigure(scheme, options);

            if (scheme == "application")
            {
                ConfigureApplicationCookie(tenant, options, scheme);
            }
            

            return options;

        }

        private void ConfigureApplicationCookie(SiteSettings tenant, CookieAuthenticationOptions options, string scheme)
        {
            if (tenant == null)
            {
                _log.LogError("tenant was null");
                return;
            }

            options.CookieName = tenant.AuthenticationScheme; 
            options.LoginPath = "/account/login";
            options.LogoutPath = "/account/logoff";
            options.AccessDeniedPath = "/account/accessdenied";

        }

        public CookieAuthenticationOptions Value
        {
            get
            {
                return ResolveOptions("application");
            }
        }

        public CookieAuthenticationOptions Get(string name)
        {
            
            return ResolveOptions(name);
        }

    }
}
