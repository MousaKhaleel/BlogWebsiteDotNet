using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var allBlogs = await _context.Blogs.Where(x => !x.IsDeleted).Include(y=>y.Comments).ToList();
        //    return View("Index", allBlogs);
        //}

        //for comenter
        //[Authorize(Roles ="Commenter, Author, Admin")]
        //public async Task<IActionResult> WriteComment()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> requireAuthorStatus(string id)
        //{
        //    return View();
        //}


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
