using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsiteDotNet.Models
{
	public class UserBlog
	{
		[ForeignKey(nameof(UserId))]
		public int UserId { get; set; }
		public User User { get; set; }

		[ForeignKey(nameof(BlogId))]
		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}
