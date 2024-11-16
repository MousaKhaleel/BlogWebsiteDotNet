using BlogWebsiteDotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Data
{
	public class AppDbContext: IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Blog>()
				.Property(e => e.CreatedDate)
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
