using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MedicalAppointingSystem.Attributes
{
    public class NoSpacesOrNumbersAttribute : RegularExpressionAttribute
    {
        public NoSpacesOrNumbersAttribute()
            : base(@"^[a-zA-Z]+$")
        {
            ErrorMessage = "The field must contain only letters and no spaces.";
        }
    }

    public class NoNumbersAttribute : RegularExpressionAttribute
    {
        public NoNumbersAttribute()
            : base("^[A-Za-z ]+$")

        {
            ErrorMessage = "The field must contain only letters and spaces and no numbers";
        }
    }
}
public class NoSymbolsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var input = value.ToString();
            if (!Regex.IsMatch(input, "^[a-zA-Z0-9]*$"))
            {
                return new ValidationResult("Only alphanumeric characters are allowed.");
            }
        }
        return ValidationResult.Success;
    }
}
