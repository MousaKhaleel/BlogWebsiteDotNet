using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
