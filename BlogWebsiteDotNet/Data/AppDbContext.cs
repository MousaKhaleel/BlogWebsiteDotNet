using BlogWebsiteDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsiteDotNet.Data
{
	public class AppDbContext: IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Blog> Blogs { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(e => e.CreatedDate)
				.HasDefaultValueSql("GETDATE()");

			modelBuilder.Entity<Blog>()
				.Property(e => e.CreatedDate)
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
