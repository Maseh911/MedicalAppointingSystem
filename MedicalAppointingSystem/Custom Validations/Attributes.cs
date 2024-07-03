using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MedicalAppointingSystem.Attributes
{
    public class NoSpacesOrNumbersOrSymbolsAttribute : RegularExpressionAttribute
    {
        public NoSpacesOrNumbersOrSymbolsAttribute()
            : base(@"^[a-zA-Z]+$")
        {
            ErrorMessage = "The field must contain only letters and no numbers, spaces, or special characters.";
        }
    }

    public class NoNumbersAttribute : RegularExpressionAttribute
    {
        public NoNumbersAttribute()
            : base("^[a-zA-z]+$")

        {
            ErrorMessage = "The field must contain only letters and spaces and no numbers";
        }
    }
}