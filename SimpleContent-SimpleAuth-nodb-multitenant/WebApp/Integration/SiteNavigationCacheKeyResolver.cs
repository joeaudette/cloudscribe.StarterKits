using cloudscribe.SimpleContent.Models;
using cloudscribe.Web.Navigation;
using cloudscribe.Web.Navigation.Caching;

namespace WebApp.Integration
{
    // this is to cache the navigation tree separately per tenant
    public class SiteNavigationCacheKeyResolver : ITreeCacheKeyResolver
    {
        public SiteNavigationCacheKeyResolver(SiteSettings tenant)
        {
            _tenant = tenant;
        }

        private SiteSettings _tenant;

        public string GetCacheKey(INavigationTreeBuilder builder)
        {
            return builder.Name + _tenant.UniqueKey;
        }
    }

    // this is for clearing the cache if pages are created or deleted
    public class SiteNavigationCacheKeys : IPageNavigationCacheKeys
    {
        public SiteNavigationCacheKeys(SiteSettings currentSite)
        {
            this.currentSite = currentSite;
        }

        private SiteSettings currentSite;

        public string PageTreeCacheKey
        {
            get { return "cloudscribe.SimpleContent.Services.PagesNavigationTreeBuilder" + currentSite.UniqueKey; }
        }

        public string XmlTreeCacheKey
        {
            get { return "cloudscribe.Web.Navigation.XmlNavigationTreeBuilder" + currentSite.UniqueKey; }
        }

        public string JsonTreeCacheKey
        {
            get { return "cloudscribe.Web.Navigation.JsonNavigationTreeBuilder" + currentSite.UniqueKey; }
        }

    }
}
