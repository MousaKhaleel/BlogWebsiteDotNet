using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
		private readonly UserManager<User> _userManager;

		public BlogController(AppDbContext dbContext, UserManager<User> userManager)
		{
			_context = dbContext;
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
        {
            var allBlogs = _context.Blogs.Where(x => !x.IsDeleted).ToList();
            return View(allBlogs);
        }

        [Authorize(Roles = "Author, Admin")]
        [HttpGet]
        public async Task<IActionResult> WriteBlog()
        {
            return View("BlogWriteForm");
        }

        [Authorize(Roles = "Author, Admin")]
        [HttpPost]
        public async Task<IActionResult> WriteBlog(BlogVM blogVM)
        {
            var blog = new Blog
            {
                BlogTitle = blogVM.BlogTitle,
                BlogPreview = blogVM.BlogPreview,
                BlogContent = blogVM.BlogContent,
                IsDeleted = false,
                UserId = blogVM.UserId
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
		public async Task<IActionResult> BlogDetails(int id)
		{
			ViewBag.blogDetails = _context.Blogs.Where(x => x.Id == id).Include(y => y.Comments);
			//var blogComments= _context.Comments.Where(x=>x.BlogId==id).ToList();

			return View();
		}

		//public async Task<IActionResult> EditBog()
		//{
		//	return View
		//}
		//public async Task<IActionResult> DeleteBog()
		//{
		//	return View
		//}
	}
}
