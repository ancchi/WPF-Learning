using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Block1Uebung3.Models {

    public class Student {
        private string _name = string.Empty;
        private bool _istAnwesend = false;

        public string Name {
            get {
                return _name;
            }
            set {
                if (!string.Equals(_name, value)) {
                    _name = value;
                }
            }
        }

        public bool IstAnwesend {
            get {
                return _istAnwesend;
            }
            set {
                _istAnwesend = value;
            }
        }
    } 
}
