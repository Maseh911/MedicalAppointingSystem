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
        [Key]
        public int PatientsId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(20)]
        [NoSpacesOrNumbers]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(20)]
        [NoSpacesOrNumbers]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(11)]
        [RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [MaxLength(50)]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "Home Address")]
        [NoSymbolsAttribute]
        public string Address { get; set; }

        [Display(Name = "Doctor")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Display(Name = "Diagnosis")]
        [ForeignKey("Diagnosis")]
        public int DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public List<AppointmentTime> AppointmentTime { get; set; }
    }
}
