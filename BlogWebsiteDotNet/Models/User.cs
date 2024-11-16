using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Buffers.Text;
using Microsoft.AspNetCore.Identity;

namespace BlogWebsiteDotNet.Models
{
	public class User:IdentityUser
	{
		
		public List<Comment>? Comments { get; set; }
		public List<Blog>? Blogs { get; set; }



	}
}
