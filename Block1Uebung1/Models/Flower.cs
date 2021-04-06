
using System.ComponentModel;
using System.Runtime.CompilerServices;

/**
 * Aufgabenstellung:
 * Erstelle eine WPF Anwendung mit einer MVVM Anwendungsarchitektur, besteht aus einem Hauptfenster und einem dazugehörendem Model. 
 * Im Hauptfenster gibt es folgende Steuerelemente: Text, ListBox, ComboBox und zwei Buttons. Jedes dieser Steuerelemente bekommt 
 * seine Daten über Binding (welche Daten ist egal). Die Aktion, die bei Clicks auf die Buttons ausgeführt wird, erfolgt auch über 
 * das dahinterliegende Model.
 */

namespace Block1Uebung1.Models {

    class Flower {
        private string nameOfFlower = string.Empty;

        public string NameOfFlower {
            get {
                return this.nameOfFlower;
            }
            set {
                if (value != this.nameOfFlower) {
                    this.nameOfFlower = value;
                }
            }
        }
    } 
}
