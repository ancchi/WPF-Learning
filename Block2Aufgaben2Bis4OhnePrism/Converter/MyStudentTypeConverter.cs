using Block2Aufgaben2Bis4OhnePrism.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block2Aufgaben2Bis4OhnePrism.Converter {
    class MyStudentTypeConverter : TypeConverter {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            
            if (sourceType == typeof(string) && sourceType.ToString().Length > 0)
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {

            if (value is string) {

                string[] studentArray = value.ToString().Split(", ");
               

                if (studentArray.Length == 3) {
                    bool isBoolean = bool.TryParse(studentArray[2], out isBoolean);
                    if (isBoolean) {
                        return new Student { PreName = studentArray[1], LastName = studentArray[0], IstAnwesend = Convert.ToBoolean(studentArray[2]) };
                    }
                    // dass der erste Eintrag ein Name und der zweite Eintrag ein Boolean ist, wird durch einen Validator sichergestellt
                } else if (studentArray.Length == 2) {
                    return new Student { PreName = studentArray[1], LastName = studentArray[0], IstAnwesend = false };
                }
            }
            //return base.ConvertFrom(context, culture, value);
            return string.Empty;
        }

    }
}
