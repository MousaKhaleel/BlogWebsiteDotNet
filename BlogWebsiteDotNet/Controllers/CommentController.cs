using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Controllers
{
    public class CommentController : Controller
    {
		private readonly UserManager<User> _userManager;

		private readonly AppDbContext _context;
        public CommentController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var allBlogs = await _context.Blogs.Where(x => !x.IsDeleted).Include(y=>y.Comments).ToList();
        //    return View("Index", allBlogs);
        //}

        //for comenter
        [Authorize(Roles = "Commenter, Author, Admin")]
        public async Task<IActionResult> WriteComment(CommentVM commentVM)
        {
            var comment = new Comment
            {
                CommentContent = commentVM.CommentContent,
                BlogId = commentVM.BlogId,
                UserId = commentVM.UserId,
                IsDeleted = false,
            };
            //contenue
			return RedirectToAction("Index", "Blog");
        }




    }
}
