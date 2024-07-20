using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Diagnosis
    {
        // This is the primary key //
        [Key]
        public int DiagnosisId { get; set; }

        [Required(ErrorMessage = "Name of Diagnosis is required")] // This field is required, an error message will popup if nothing is inside the field //
        [Display(Name = "Diagnosis Name")] // This will display DiagnosisName with Diagnosis Name //
        [MaxLength(30)] // This limits the max characters for this field to 30 //
        public string DiagnosisName { get; set; }

        [Required (ErrorMessage = "Symptoms is required")] // This is a required field //
        [MaxLength(50)] // This limits the max characters for this field to 50 //
        public string Symptoms { get; set; }
    }
}