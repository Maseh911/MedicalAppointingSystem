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

        [Required, MaxLength(20)]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(11), Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [MaxLength(50), EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "Home Address")]
        public string Address { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DiagnosisId { get; set; }
        

        public List<Diagnosis> Diagnosis { get; set; }
        public List<AppointmentTime> AppointmentTime { get; set; }
    }
}
