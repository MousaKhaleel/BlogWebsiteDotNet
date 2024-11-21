using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        //writecomment
        //requireAuthorStatus

        //[Authorize(Roles ="Admin")]
        //public async Task<IActionResult> grantAuthorStatus()
        //{
        //	return View
        //}

        //[Authorize(Roles ="Author")]
        //public async Task<IActionResult> WriteBog()
        //{
        //	return View
        //}
    }
}
