using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class AppointmentTime
    {
        [Key]
        public int AppointedId { get; set; }
       
        [Required(ErrorMessage = "Appointment Time is required")]
        [Display(Name = "Appointment Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppointedTime { get; set; }

        [ForeignKey("Patients")]
        public int PatientId { get; set; }
        public Patient Patients { get; set; }
    }
}

