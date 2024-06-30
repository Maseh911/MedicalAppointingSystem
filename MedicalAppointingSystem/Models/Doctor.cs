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
        [NoSpacesOrNumbers]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(25)]
        [NoSpacesOrNumbers]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(11)]
        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [ForeignKey("Hospital")]
        public List<Hospital> Hospitals { get; set; }
        public List<Patient> Patients { get; set; }
    }
}