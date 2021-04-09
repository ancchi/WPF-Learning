using System.ComponentModel;
using System.Runtime.CompilerServices;
using Block1Uebung4.Converters;

namespace Block1Uebung4.Models {


    //[TypeConverter(typeof(StudentTypeConverter))]
    [TypeConverter(typeof(StudentToColorTypeConverter))]
    public class Student : INotifyPropertyChanged {
        private string name = string.Empty;
        private bool istAnwesend = false;

       public string Name {
            get {
                return name;
            }
            set {
                if (!string.Equals(name, value)) {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IstAnwesend {
            get {
                return istAnwesend;
            }
            set {
                istAnwesend = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() {
            return Name + ", " + IstAnwesend;
        }
    }
}