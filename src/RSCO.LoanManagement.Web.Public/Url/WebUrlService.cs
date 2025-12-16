using Abp.Dependency;
using RSCO.LoanManagement.Configuration;
using RSCO.LoanManagement.Url;
using RSCO.LoanManagement.Web.Url;

namespace RSCO.LoanManagement.Web.Public.Url
{
    public class WebUrlService : WebUrlServiceBase, IWebUrlService, ITransientDependency
    {
        public WebUrlService(
            IAppConfigurationAccessor appConfigurationAccessor) :
            base(appConfigurationAccessor)
        {
        }

        public override string WebSiteRootAddressFormatKey => "App:WebSiteRootAddress";

        public override string ServerRootAddressFormatKey => "App:AdminWebSiteRootAddress";
    }
}