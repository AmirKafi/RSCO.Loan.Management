using Abp.AspNetCore.Mvc.Authorization;
using RSCO.LoanManagement.Authorization.Users.Profile;
using RSCO.LoanManagement.Graphics;
using RSCO.LoanManagement.Storage;

namespace RSCO.LoanManagement.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService,
            IImageValidator imageValidator) :
            base(tempFileCacheManager, profileAppService, imageValidator)
        {
        }
    }
}