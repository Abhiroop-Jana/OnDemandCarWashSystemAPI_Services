using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnDemandCarWashSystemAPI.Models
{
    public class Login
    {
        [Required]
        [Column(TypeName ="VARCHAR(10")]
        public string Role { get; set; }
        
        [Required]
        [Column(TypeName ="VARCHAR(30)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName ="VARCHAR(15")]
        public string Password { get; set; }
    }
}
