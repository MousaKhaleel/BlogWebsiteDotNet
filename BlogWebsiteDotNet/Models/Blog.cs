using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.Models
{
	public class Blog
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string BlogName { get; set; }
		public string BlogContent { get; set; }

	}
}
