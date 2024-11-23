using BlogWebsiteDotNet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsiteDotNet.ViewModels
{
	public class CommentVM
	{
		public string Id { get; set; }
		public string CommentContent { get; set; }
		public bool IsDeleted { get; set; }

		public int BlogId { get; set; }
		public Blog Blog { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
	}
}
