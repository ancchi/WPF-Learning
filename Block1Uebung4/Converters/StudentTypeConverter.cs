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
            if (value is string) { // base.ConvertFrom kann keinen String verarbeiten
                string valueAsString = value as string;

                // TODO: mache aus der Zeichenkette einen Studenten
                string[] studentArray = valueAsString.Split(", ");
                bool transformed;

                if (studentArray.Length == 2 && bool.TryParse(studentArray[1].ToString(), out transformed)) {
                    return new Student { Name = studentArray[0], IstAnwesend = Convert.ToBoolean(studentArray[1]) };
                } else {
                    return new Student { Name = studentArray[0], IstAnwesend = false };
                }   
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
