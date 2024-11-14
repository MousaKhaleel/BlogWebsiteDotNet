using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.Models
{
	public class Comment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string CommentContent { get; set; }

		[ForeignKey(nameof(BlogId))]
		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}
