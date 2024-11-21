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
        public bool IsDeleted { get; set; }
        //public bool IsModified { get; set; }


        [ForeignKey(nameof(BlogId))]
		public int BlogId { get; set; }
		public Blog Blog { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
		public User User { get; set; }
    }
}
