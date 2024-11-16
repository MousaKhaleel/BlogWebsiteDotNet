using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Buffers.Text;

namespace BlogWebsiteDotNet.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string UserName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string UserEmail { get; set; }
		//public string UserPhone { get; set; }
		public string UserPassword { get; set; }
		public DateTime CreatedDate { get; set; }
		//public Base64 ProfileImage { get; set; }
		public bool IsDeleted { get; set; }

		public List<Comment> Comments { get; set; }
		public List<UserRole> UserRoles { get; set; }
        public List<UserBlog>? UserBlogs { get; set; }



    }
}
