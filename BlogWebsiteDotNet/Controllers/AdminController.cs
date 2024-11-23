using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly AppDbContext _context;
		private readonly UserManager<User> _userManager;

		public AdminController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
		{
			var prendingRequests= _context.StatusRequests.Where(x=>x.requestStatus=="Pending").ToList();
			return View(prendingRequests);
		}
		public async Task<IActionResult> grantAuthorStatus(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			await _userManager.AddToRoleAsync(user, "Author");
			var req = _context.StatusRequests.Where(x=>x.UserId==user.Id).FirstOrDefault();
			req.requestStatus = "Approved";
			_context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> RefuseAuthorStatus(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			var req = _context.StatusRequests.Where(x => x.UserId == user.Id).FirstOrDefault();
			req.requestStatus = "Denied";
			_context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
