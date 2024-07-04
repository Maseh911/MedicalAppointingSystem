using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
       
        [Required(ErrorMessage = "Appointment Time is required")]
        [Display(Name = "Appointment Time")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd-HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

