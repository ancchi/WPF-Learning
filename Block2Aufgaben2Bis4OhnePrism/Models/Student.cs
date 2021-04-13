using Block2Aufgaben2Bis4OhnePrism.Converter;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Block2Aufgaben2Bis4OhnePrism.Models {

    [TypeConverter(typeof(MyStudentTypeConverter))]
    class Student : INotifyPropertyChanged {

        private string preName = string.Empty;
        private string lastName = string.Empty;
        private bool istAnwesend = false;

        public string PreName {
            get => preName;
            set {
                if (!preName.Equals(value)) {
                    preName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string LastName {
            get => lastName;
            set {
                if (!lastName.Equals(value)) {
                    lastName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IstAnwesend {
            get => istAnwesend;
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
            return LastName + ", " + PreName + ", " + IstAnwesend;
        }
    }
}
