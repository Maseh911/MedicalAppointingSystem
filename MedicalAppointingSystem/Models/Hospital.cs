using MedicalAppointingSystem.Attributes;
using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MedicalAppointingSystem.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
    
        [Required(ErrorMessage = "Hospital name is required")]
        [Display(Name = "Hospital Name")]
        [NoNumbers] 
        public string HospitalName { get; set; }

        [Display(Name = "Address")]
        [NoNumbers]
        public string Address { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
