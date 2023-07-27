using Microsoft.AspNetCore.Mvc;

namespace LiveSportNotification.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
