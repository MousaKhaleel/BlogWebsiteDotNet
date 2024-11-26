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
                UserId = blogVM.UserId,
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
		public async Task<IActionResult> BlogDetails(int id)
		{
			var blogDetails = await _context.Blogs.Where(x => x.Id == id).Include(y=>y.User).FirstAsync();
			var blogComments= await _context.Comments.Where(x=>x.BlogId==id).Include(y=>y.User).ToListAsync();

            var blogAndComments = new BlogAndCommentsVM
            {
                BlogId = blogDetails.Id,
                BlogTitle = blogDetails.BlogTitle,
                BlogContent = blogDetails.BlogContent,
                BlogAuthorId= blogDetails.UserId,
                //BlogIsDeleted = blogDetails.IsDeleted,
                Comments = blogComments.ToList(),
            };

            return View(blogAndComments);
		}

        //public async Task<IActionResult> EditBog()
        //{
        //	return View
        //}
        public async Task<IActionResult> DeleteBog(int id)
        {
            var blogToDelete= _context.Blogs.Where(x => x.Id==id).FirstOrDefault();
			//blogToDelete.IsDeleted = true;
            _context.Blogs.Remove(blogToDelete);
            await _context.SaveChangesAsync();
			return RedirectToAction("Index");

        }

        [Authorize(Roles = "Commenter, Author, Admin")]
		public async Task<IActionResult> WriteComment(BlogAndCommentsVM blogAndComments)
		{
			var comment = new Comment
			{
				CommentContent = blogAndComments.CommentContent,
				BlogId = blogAndComments.BlogId,
				UserId = blogAndComments.CommenterId,
				IsDeleted = false,
			};
			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();
			return RedirectToAction("BlogDetails", "Blog", new { id=blogAndComments.BlogId });
		}
	}
}
