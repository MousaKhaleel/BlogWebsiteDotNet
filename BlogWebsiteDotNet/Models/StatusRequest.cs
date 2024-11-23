using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebsiteDotNet.Models
{
    public class StatusRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }

        public string requestLevel { get; set; }
        public string requestStatus { get; set; }
    }
}
