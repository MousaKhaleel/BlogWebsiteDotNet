﻿using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using BlogWebsiteDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsiteDotNet.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var allBlogs = _context.Blogs.Where(x => !x.IsDeleted).ToList();
            return View(allBlogs);
        }
        public async Task<IActionResult> BlogDetails(int id)
        {
            var blogComments= _context.Comments.Where(x=>x.BlogId==id).ToList();

            return View(blogComments);
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
                BlogContent = blogVM.BlogContent,
                IsDeleted = false,
                UserId = blogVM.UserId
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return View("BlogWriteForm", "Blog");
        }

    }
}
