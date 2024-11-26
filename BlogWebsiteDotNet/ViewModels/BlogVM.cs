using BlogWebsiteDotNet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsiteDotNet.ViewModels
{
	public class BlogVM
	{
		public int Id { get; set; }
		public string BlogTitle { get; set; }
        public string BlogPreview { get; set; }
        public string BlogContent { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsDeleted { get; set; }
		public string? BlogImage { get; set; }

		public string UserId { get; set; }
		public User User { get; set; }

		public List<Comment>? Comments { get; set; }
	}
}
