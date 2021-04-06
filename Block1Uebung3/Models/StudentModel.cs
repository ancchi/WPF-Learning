using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Block1Uebung3.Models {
    class StudentModel {}
        

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

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    } 
}
