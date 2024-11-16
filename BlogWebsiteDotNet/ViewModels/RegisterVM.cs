using System.ComponentModel.DataAnnotations;

namespace BlogWebsiteDotNet.ViewModels
{
    public class RegisterVM
    {
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password",ErrorMessage ="Does not match")]
        public string? ConfirmPassword { get; set; }
    }
}
