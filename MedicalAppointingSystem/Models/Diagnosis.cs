using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }
        public string Diagnosis_Name { get; set; }

        [ForeignKey("Patients")]
        public List<Patient> Patients { get; set; }
    }
}