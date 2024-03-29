﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace ValidationHandling
{
    public class AgeRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public AgeRangeRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age = 0;

            try
            {
                if (((string)value).Length > 0)
                    age = Int32.Parse((String)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if ((age < Min) || (age > Max))
            {
                return new ValidationResult(false,
                  $"Please enter an age in the range: {Min}-{Max}.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
