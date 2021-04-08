using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block1Uebung4.Models
{
    /// <summary>
    /// Dieser TypeConverter kann aus einer Zeichenkette eine Instanz von Student machen.
    /// </summary>
    class StudentTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Wir können nur aus einer Zeichenkette einen Studenten machen
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string valueAsString = value as string;

            // TODO: mache aus der Zeichenkette einen Studenten

            return null;    // noch passiert hier nichts
        }
    }
}
