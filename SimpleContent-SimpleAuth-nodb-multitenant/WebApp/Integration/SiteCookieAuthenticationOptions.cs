using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace WebApp.Integration
{
    public class SiteCookieAuthenticationOptions : IOptionsMonitor<CookieAuthenticationOptions>
    {
        public SiteCookieAuthenticationOptions(
            IOptionsFactory<CookieAuthenticationOptions> factory,
            IEnumerable<IOptionsChangeTokenSource<CookieAuthenticationOptions>> sources,
            IOptionsMonitorCache<CookieAuthenticationOptions> cache,
            IPostConfigureOptions<CookieAuthenticationOptions> cookieOptionsInitializer,
            IHttpContextAccessor httpContextAccessor,
            ILogger<SiteCookieAuthenticationOptions> logger
            )
        {
            _cookieOptionsInitializer = cookieOptionsInitializer;
            _httpContextAccessor = httpContextAccessor;
            _log = logger;
			
			_factory = factory;
            _sources = sources;
            _cache = cache;

            foreach (var source in _sources)
            {
                ChangeToken.OnChange<string>(
                    () => source.GetChangeToken(),
                    (name) => InvokeChanged(name),
                    source.Name);
            }
        }

        private IPostConfigureOptions<CookieAuthenticationOptions> _cookieOptionsInitializer;
        private IHttpContextAccessor _httpContextAccessor;
        private ILogger _log;

        private readonly IOptionsMonitorCache<CookieAuthenticationOptions> _cache;
        private readonly IOptionsFactory<CookieAuthenticationOptions> _factory;
        private readonly IEnumerable<IOptionsChangeTokenSource<CookieAuthenticationOptions>> _sources;
        internal event Action<CookieAuthenticationOptions, string> _onChange;

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

            options.Cookie.Name = tenant.AuthenticationScheme; 
            options.LoginPath = "/account/login";
            options.LogoutPath = "/account/logoff";
            options.AccessDeniedPath = "/account/accessdenied";

        }

        public CookieAuthenticationOptions CurrentValue
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

        private void InvokeChanged(string name)
        {
            name = name ?? Options.DefaultName;
            _cache.TryRemove(name);
            var options = Get(name);
            if (_onChange != null)
            {
                _onChange.Invoke(options, name);
            }
        }

        public IDisposable OnChange(Action<CookieAuthenticationOptions, string> listener)
        {
            _log.LogDebug("onchange invoked");

            var disposable = new ChangeTrackerDisposable(this, listener);
            _onChange += disposable.OnChange;
            return disposable;
        }


        internal class ChangeTrackerDisposable : IDisposable
        {
            private readonly Action<CookieAuthenticationOptions, string> _listener;
            private readonly SiteCookieAuthenticationOptions _monitor;

            public ChangeTrackerDisposable(SiteCookieAuthenticationOptions monitor, Action<CookieAuthenticationOptions, string> listener)
            {
                _listener = listener;
                _monitor = monitor;
            }

            public void OnChange(CookieAuthenticationOptions options, string name) => _listener.Invoke(options, name);

            public void Dispose() => _monitor._onChange -= OnChange;
        }

    }
}
