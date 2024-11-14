using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.Models
{
	public class Role
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string RoleName { get; set; }

		public List<UserRole> UserRoles { get; set; }
	}
}
