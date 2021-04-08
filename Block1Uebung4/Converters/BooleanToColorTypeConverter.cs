using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Block1Uebung4.Converters {
    
    /// <summary>
    /// Dieser TypeConverter kann aus einem Studenten-Objekt ermitteln, ob er anwesend ist und die Farbe dementsprechend anpassen
    /// </summary>
    class BooleanToColorTypeConverter : TypeConverter {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {

            
            if (value is string && value != null) {
            string[] studentArray = value.ToString().Split(", ");

            return studentArray[1].ToLower().Equals("true") ? new SolidColorBrush(Colors.LightGreen) : new SolidColorBrush(Colors.Red);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            if (sourceType == typeof(string)) {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }
    }
}
