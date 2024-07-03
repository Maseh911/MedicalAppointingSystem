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
    
        [Required]
        [Display(Name = "Hospital Name")]
        [MaxLength(30)]
        [NoNumbers] 
        public string HospitalName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [MaxLength(50)]
        [NoNumbers]
        public string Address { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
