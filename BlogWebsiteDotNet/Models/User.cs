using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string UserName { get; set; }
		public int UserDateOfBirth { get; set; }
		public string UserEmail { get; set; }

		public DateTime CreatedDate { get; set; }
		public bool isDeleted { get; set; }
	}
}
