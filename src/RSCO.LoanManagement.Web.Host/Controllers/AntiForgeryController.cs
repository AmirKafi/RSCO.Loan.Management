using Microsoft.AspNetCore.Antiforgery;

namespace RSCO.LoanManagement.Web.Controllers
{
    public class AntiForgeryController : LoanManagementControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
