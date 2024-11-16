using BlogWebsiteDotNet.Data;
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
        public IActionResult Index()
		{
            var allBlogs= _context.Blogs.Where(x=>!x.IsDeleted).ToList();
			return View(allBlogs);
		}
	}
}
