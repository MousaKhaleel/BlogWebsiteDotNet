using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsiteDotNet.Models
{
	public class UserRole
	{
		[ForeignKey(nameof(UserId))]
		public int UserId { get; set; }
		public User User { get; set; }

		[ForeignKey(nameof(RoleId))]
		public int RoleId { get; set; }
		public Role Role { get; set; }
	}
}
