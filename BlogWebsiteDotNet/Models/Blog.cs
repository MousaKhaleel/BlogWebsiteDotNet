using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.Models
{
	public class Blog
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string BlogTitle { get; set; }
		public string BlogContent { get; set; }
		public DateTime CreatedDate { get; set; }
		//public Base64 BlogImage { get; set; }
		//public int BlogView {  get; set; }
		public bool IsDeleted { get; set; }
		//public bool IsModified { get; set; }

		public List<Comment>? Comments { get; set; }
		public List<UserBlog> AuthorBlogs { get; set; }
        //public List<BlogCategory>? BlogCategories { get; set; }

    }
}
