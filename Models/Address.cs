using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnDemandCarWashSystemAPI.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustId { get; set; }
        [ForeignKey("CustId")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please enter the address"), MaxLength(50)]
        [Column(TypeName = "VARCHAR(50)")]
        public string CustAddress { get; set; }


        [Required(ErrorMessage = "Please enter city"), MaxLength(50)]
        [Column(TypeName = "VARCHAR(50)")]
        public string City { get; set; }


        [Required(ErrorMessage = "Please enter state"), MaxLength(50)]
        [Column(TypeName = "VARCHAR(50)")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter pincode"), MaxLength(6)]
        public int Pincode { get; set; }
    }
}
