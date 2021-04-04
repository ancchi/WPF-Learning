
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Block1Uebung1.Models {
    public class FlowerModel {
    }

    class Flower: INotifyPropertyChanged {
        private string nameOfFlower = string.Empty;

        public string NameOfFlower {
            get {
                return this.nameOfFlower;
            }
            set {
                if (value != this.nameOfFlower) {
                    this.nameOfFlower = value;
                    RaisePropertyChanged("NameOfFlower");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    } 
}
