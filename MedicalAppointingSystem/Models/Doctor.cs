using MedicalAppointingSystem.Attributes;
using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(25)]
        [NoSpacesOrNumbersOrSymbolsAttribute]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(25)]
        [NoSpacesOrNumbersOrSymbolsAttribute]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [ForeignKey("Hospital")]
        [Required]
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}


