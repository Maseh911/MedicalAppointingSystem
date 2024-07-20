using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
       
        [Required(ErrorMessage = "Appointment Time is required")] // This field is required, an error message will popup if nothing is inside the field //
        [Display(Name = "Appointment Time")] // This will display Date as Appointment Time //
        public DateTime Date { get; set; }

        [Required] // This is a required field //
        [ForeignKey("Patient")] // This is a foreign key from the Patient table //
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required] // This is a required field //
        [ForeignKey("Doctor")] // This is a foreign key from the Doctor table //
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

