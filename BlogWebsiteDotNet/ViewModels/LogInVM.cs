using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.ViewModels
{
    public class LogInVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Required")]
        public string? UserName { get; set; }


        //[Required(ErrorMessage = "Required")]
        //public string? Email { get; set; }


        [Required(ErrorMessage = "Required")]
        public string? Password { get; set; }

        public bool rememberMe { get; set; }
    }
}
