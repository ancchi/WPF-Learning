using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Block1Uebung1.Validation {
    public class ShouldNotBeEmptyValidationRule : ValidationRule {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            
            if (value == null || string.IsNullOrEmpty(value.ToString())) {
                return new ValidationResult(false, "Das Feld sollte nicht leer sein");
            }

            return ValidationResult.ValidResult;
        }
    }
}
