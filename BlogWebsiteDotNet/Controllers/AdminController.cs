using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
        private readonly AppDbContext _context;
		private readonly UserManager<User> _userManager;

		public AdminController(AppDbContext dbContext, UserManager<User> userManager)
		{
			_context = dbContext;
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			var prendingRequests= await _context.StatusRequests.Where(x=>x.requestStatus=="Pending").ToListAsync();
			return View(prendingRequests);
		}
		public async Task<IActionResult> grantAuthorStatus(int id)
		{
			var req = _context.StatusRequests.Where(x => x.Id == id).Include(y=>y.User).FirstOrDefault();
			var user = await _userManager.FindByIdAsync(req.UserId);
			await _userManager.AddToRoleAsync(user, "Author");
			req.requestStatus = "Approved";
			_context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> RefuseAuthorStatus(int id)
		{
			var req = _context.StatusRequests.Where(x => x.Id == id).FirstOrDefault();
			var user = await _userManager.FindByIdAsync(req.UserId);
			req.requestStatus = "Denied";
			_context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
