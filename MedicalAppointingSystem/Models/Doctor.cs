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

        [Required(ErrorMessage = "First name is required")] // This is a required field that will pop up an error message if nothing is entered //
        [MaxLength(25)] // This limits the max characters for this field to 25 //
        [NoSpacesOrNumbersOrSymbolsAttribute] // This ensures that no spaces, numbers or symbols are added into this field //
        [Display(Name = "First Name")] // This displays FirstName as First Name //
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")] // This is a required field that will pop up an error message if nothing is entered //
        [MaxLength(25)] // This limits the max characters for this field to 25 //
        [NoSpacesOrNumbersOrSymbolsAttribute] // This ensures that no spaces, numbers or symbols are added into this field //
        [Display(Name = "Last Name")] // This displays LastName as Last Name //
        public string LastName { get; set; }

        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Please enter a valid phone number.")] // This ensures that the phone number is only in New Zealand format //
        [MaxLength(11)] // This limits the max characters for this field to 11 //
        [Required(ErrorMessage = "Phone number is required")] // This is a required field that will pop up an error message if nothing is entered //
        public string Phone { get; set; }

        [MaxLength(50)] // This limits the max characters for this field to 50 //
        [EmailAddress] // This is a validation within Asp.net that ensures whatever is put in is in a email format //
        [Required(ErrorMessage = "Email address is required")] // This is a required field that will pop up an error message if nothing is entered //
        public string Email { get; set; }

        [ForeignKey("Hospital")] // This represents Hospital as a Foreign Key for this table //
        [Required] // This is a required field //
        [Display(Name = "Hospital")] // This will Display HospitalID as Hospital //
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}


