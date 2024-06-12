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
        public string HospitalName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
