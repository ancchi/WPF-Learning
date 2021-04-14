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
                string[] seperator = { ", ", ","};
                string[] studentArray = value.ToString().Split(seperator, StringSplitOptions.None);
                bool arrayElementsNotEmpty = false;
               
                // sind die Elemente des Arrays alle gefüllt?
                for (int i = 0; i < studentArray.Length; i++) {
                    if (studentArray[i].Trim().Length > 0) {
                        arrayElementsNotEmpty = true;
                    } else {
                        arrayElementsNotEmpty = false;
                        break;
                    }
                }

                if (arrayElementsNotEmpty) { // wenn kein Element leer ist, kann man sie zählen
                    if (studentArray.Length == 3) {
                       
                        bool istAnwesend;
                        if (studentArray[2].ToLower().Equals("ja")) {
                            istAnwesend = true;
                        } else if (studentArray[2].ToLower().Equals("nein")) {
                            istAnwesend = false;
                        } else {
                            return null;
                        }

                        return new Student { PreName = studentArray[1], LastName = studentArray[0], IstAnwesend = istAnwesend };

                      // nur Vor- und Nachname wurden eingegeben
                    } else if (studentArray.Length == 2) {
                        return new Student { PreName = studentArray[1], LastName = studentArray[0], IstAnwesend = false };
                    }
                }
            }
            //return base.ConvertFrom(context, culture, value);
            return string.Empty;
        }

    }
}
