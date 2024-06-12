using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(11), Phone]
        public string Phone { get; set; }

        [MaxLength(50), EmailAddress]
        public string Email { get; set; }

        [ForeignKey("Hospital")]
        public List<Hospital> Hospitals { get; set; }
        public List<Patient> Patients { get; set; }
    }
}