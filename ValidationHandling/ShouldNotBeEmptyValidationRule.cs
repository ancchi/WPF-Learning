using System.Globalization;
using System.Windows.Controls;

namespace ValidationHandling
{
    public class ShouldNotBeEmptyValidationRule : ValidationRule
    {

        // ValidationRule für FirstName
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Value should not be empty");
            }

            return ValidationResult.ValidResult;
        }
    }
}
