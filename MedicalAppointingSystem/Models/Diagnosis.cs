using MedicalAppointingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointingSystem.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }

        [Required(ErrorMessage = "Name of Diagnosis is required")]
        [Display(Name = "Diagnosis Name")]
        [MaxLength(30)]
        public string DiagnosisName { get; set; }

        [Required]
        [Display(Name ="Symptoms")]
        [MaxLength(120)]
        public string Symptoms { get; set; }
    }
}