using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Block1Uebung3.Models {

    public class Student : INotifyPropertyChanged {
        private string _name = string.Empty;
        private bool _istAnwesend = false;

        public string Name {
            get {
                return _name;
            }
            set {
                if (!string.Equals(_name, value)) {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IstAnwesend {
            get {
                return _istAnwesend;
            }
            set {
                _istAnwesend = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}
