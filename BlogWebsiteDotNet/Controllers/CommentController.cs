using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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






    }
}
