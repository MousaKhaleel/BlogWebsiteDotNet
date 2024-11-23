using BlogWebsiteDotNet.Models;

namespace BlogWebsiteDotNet.ViewModels
{
	public class BlogAndCommentsVM
	{
		public int BlogId { get; set; }
		public string BlogTitle { get; set; }
		public string BlogPreview { get; set; }
		public string BlogContent { get; set; }
		//public DateTime CreatedDate { get; set; }
		//public bool BlogIsDeleted { get; set; }
		public string BlogAuthorId { get; set; }
		//public User AuthorUser { get; set; }

		public List<Comment>? Comments { get; set; }

		//-------------------------------------------------
		public string CommentId { get; set; }
		public string CommentContent { get; set; }
		//public bool CommentIsDeleted { get; set; }


		//public int CommentedOnBlogId { get; set; }
		//public Blog CommentedOnBlog { get; set; }

		public string CommenterId { get; set; }
		public User CommenterUser { get; set; }
	}
}
