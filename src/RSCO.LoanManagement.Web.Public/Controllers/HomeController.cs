using Microsoft.AspNetCore.Mvc;
using RSCO.LoanManagement.Web.Controllers;

namespace RSCO.LoanManagement.Web.Public.Controllers
{
    public class HomeController : LoanManagementControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}