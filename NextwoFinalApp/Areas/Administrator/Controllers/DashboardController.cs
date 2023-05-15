using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace NextwoFinalApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
