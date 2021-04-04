using System.ComponentModel;
using System.Runtime.CompilerServices;

/**
 * Aufgabe:
 * Erstelle eine WPF Anwendung mit einer MVVM Anwendungsarchitektur, besteht aus einem Hauptfenster und einem dazugehörendem Model. 
 * Im Hauptfenster gibt es zwei Listen (Liste A und Liste B) sowie zwei Schaltflächen (A und B). Beim Start ist die Liste A mit zehn 
 * Einträgen gefüllt, die Liste B ist leer. Mit der Schaltfläche A wird das in der Liste A markierte Element der Liste B hinzugefügt. 
 * Die Schaltfläche A ist nur aktiv, wenn in der Liste A ein Eintrag ausgewählt ist. Schaltfläche B geht den umgekehrten Weg.
 */


namespace Block1Uebung2.Models {
    public class TeamMemberModel {
    }

    class TeamMember: INotifyPropertyChanged {
        private string memberName;

        public string MemberName {
            get {
                return this.memberName;
            } 
            set {
                if (memberName != value) {
                    memberName = value;
                    RaisePropertyChanged();
                }
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
