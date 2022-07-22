using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnDemandCarWashSystemAPI.Models
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter the name"), MaxLength(30)]
        [Column(TypeName = "VARCHAR(30)")]
        public string Name { get; set; }


        [Column(TypeName = "VARCHAR(50)")]
        [MaxLength(50)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please enter the price")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Required Field"), MaxLength(20)]
        [Column(TypeName = "VARCHAR(20)")]
        public string Status { get; set; }
    }
}
