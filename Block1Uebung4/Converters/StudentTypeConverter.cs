using System;
using System.ComponentModel;
using System.Globalization;
using Block1Uebung4.Models;

namespace Block1Uebung4.Converters
{
    /// <summary>
    /// Dieser TypeConverter kann aus einer Zeichenkette eine Instanz von Student machen.
    /// </summary>
    class StudentTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Wir können nur aus einer Zeichenkette einen Studenten machen
            if (sourceType == typeof(string) && sourceType.ToString().Length > 0)
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string) {
                
                string[] studentArray = value.ToString().Split(", ");

                if (studentArray.Length == 2) {
                    // dass der erste Eintrag ein Name und der zweite Eintrag ein Boolean ist, wird durch einen Validator sichergestellt
                    return new Student { Name = studentArray[0], IstAnwesend = Convert.ToBoolean(studentArray[1]) };
                } else {
                    return new Student { Name = studentArray[0], IstAnwesend = false };
                }   
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
