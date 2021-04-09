using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Media;

namespace Block1Uebung4.Converters {
    
    /// <summary>
    /// Dieser TypeConverter kann aus einem Studenten-Objekt-String ermitteln, ob er anwesend ist und die Farbe dementsprechend anpassen
    /// </summary>
    class StudentToColorTypeConverter : TypeConverter {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {

             // values werden von Liste übergeben und haben immer dasselbe Format (String, Boolean)
            if (value is string && value != null) {
                string[] studentAnwesendArray = value.ToString().Split(", ");
                return studentAnwesendArray[1].ToLower().Equals("true") ? new SolidColorBrush(Colors.LightGreen) : new SolidColorBrush(Colors.Red); 
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
