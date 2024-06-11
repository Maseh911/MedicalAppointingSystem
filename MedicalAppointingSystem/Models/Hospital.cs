using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MedicalAppointingSystem.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
