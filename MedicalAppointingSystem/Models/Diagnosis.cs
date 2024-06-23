using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }
        [Required]
        [Display(Name = "Diagnosis Name")]
        public string Diagnosis_Name { get; set; }

        public List<Patient> Patients { get; set; }
    }
}