using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnDemandCarWashSystemAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter yout first name"), MaxLength(30)]
        [Column(TypeName = "VARCHAR(30)")]
        public string FirstName { get; set; }


        [Column(TypeName = "VARCHAR(30)")]
        [MaxLength(30)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please enter your Email Id"), MinLength(3)]
        [Column(TypeName ="VARCHAR(50)")]
        [EmailAddress(ErrorMessage ="Email Id is not valid")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter your phone number")]
        [Column(TypeName = "VARCHAR(10)")]
        [MinLength(10, ErrorMessage = "Not a valid phone number")]
        public string PhnNumber { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        [Column(TypeName = "VARCHAR(15)")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please confirm your password")]
        [StringLength(15, ErrorMessage = "Must be between 5 and 15 characters", MinimumLength = 5)]
        [Column(TypeName = "VARCHAR(15)")]
        [Compare("Password")]
        public string CnfPassword { get; set; }

    }
}
