using MedicalAppointingSystem.Attributes;
using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MedicalAppointingSystem.Models
{
    public class Hospital
    {
        // This is the primary key for the Hospitals table //
        [Key]
        public int HospitalId { get; set; }
    
        [Required (ErrorMessage = "Hospital name is required")] // This is a required field //
        [Display(Name = "Hospital Name")] // The HospitalName will be displayed as Hospital Name //
        [MaxLength(30)] // This limits the max characters for this field to 30 //
        [NoNumbers] // This ensures that no numbers and symbols are added to this field //
        public string HospitalName { get; set; }

        [Required (ErrorMessage = "Hospital address is required")] // This is a required field //
        [MaxLength(50)] // This limits the max characters for this field to 50 //
        [NoNumbers] // This ensures that no numbers and symbols are added to this field //
        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; } // This creates a one to many relationship with the doctors table //
    }
}
