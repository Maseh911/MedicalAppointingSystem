using MedicalAppointingSystem.Attributes;
using MedicalAppointingSystem.Models;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace MedicalAppointingSystem.Models
{
    public class Patient
    {
        // This is the primary key for the Patients table //
        [Key]
        public int PatientId { get; set; } 


        [Required(ErrorMessage = "First name is required.")] // This field is required, an error message will popup if nothing is inside the field //
        [MaxLength(25)] // This limits the max characters for this field to 25 //
        [NoSpacesOrNumbersOrSymbolsAttribute] // This ensures that no spaces, numbers or symbols are added into this field //
        [Display(Name = "First Name")] // This displays FirstName as First Name //

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")] // This field is required, an error message will popup if nothing is inside the field //
        [MaxLength(25)] // This limits the max characters for this field to 25 //
        [NoSpacesOrNumbersOrSymbolsAttribute] // This ensures that no spaces, numbers or symbols are added into this field //
        [Display(Name = "Last Name")] // This displays LastName as Last Name //
        public string LastName { get; set; }

        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Please enter a valid phone number.")] // This ensures that the phone number is only in New Zealand format //
        [MaxLength(11)] // This limits the max characters for this field to 11 //
        [Display(Name = "Phone Number")] // This displays Phone as Phone Number //
        public string Phone { get; set; }

        [MaxLength(50)] // This limits the max characters for this field to 50 //
        [Display(Name = "Email Address")] // This displays Email as Email Address //
        [EmailAddress] // This is a validation within Asp.net that ensures whatever is put in is in a email format //
        public string Email { get; set; }

        [MaxLength(50)] // This limits the max characters for this field to 50 //
        [Display(Name = "Home Address")] // This displays Address as Home Address //
        public string Address { get; set; }

        [Required]  // This field is required //
        [Display(Name = "Diagnosis")] // This will Display DiagnosisId as Diagnosis //
        [ForeignKey("Diagnosis")] // This represents Diagnosis as a Foreign Key for this table //
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; } // This links the 

    }
}
