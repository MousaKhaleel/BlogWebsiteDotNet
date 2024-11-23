using BlogWebsiteDotNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly AppDbContext _context;
        public AdminController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
		{
			var prendingRequests= _context.StatusRequests.Where(x=>x.requestStatus=="Pending").ToList();
			return View(prendingRequests);
		}
		public async Task<IActionResult> grantAuthorStatus()
		{
			return RedirectToAction("Index");
		}
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RefuseAuthorStatus()
		{

			return RedirectToAction("Index");
		}
	}
}
