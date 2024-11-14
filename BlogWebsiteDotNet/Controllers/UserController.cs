using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
