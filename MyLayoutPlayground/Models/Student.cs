using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLayoutPlayground.Models {
    class Student : INotifyPropertyChanged {
        private string preName;
        private string lastName;
        private string imgPath;

        public string PreName {
            get => preName;
            set {
                if (!string.Equals(preName, value)) {
                    preName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string LastName {
            get => lastName;
            set {
                if(!string.Equals(lastName, value)) {
                    lastName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ImgPath {
            get => imgPath;
            set {
                if(!string.Equals(imgPath, value)) {
                    imgPath = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
