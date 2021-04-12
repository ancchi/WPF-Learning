using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValidationHandling
{
    public class Street
    {
        public virtual string Name { get; set; }

        public virtual string Number { get; set; }
    }


    public class StreetWithNotification : Street, INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public override string Name
        {
            // Getter und Setter werden hier mit den Properties der Basisklasse initialisiert.
            get => base.Name;
            set
            {
                if (!string.Equals(base.Name, value))
                {
                    base.Name = value; // nach Änderung des Wertes des Textfeldes wird dieser Setter als erstes angesteuert
                    RaisePropertyChanged();
                }
            }
        }

        public override string Number
        {
            get => base.Number;
            set
            {
                if (!string.Equals(base.Number, value))
                {
                    base.Number = value;
                    RaisePropertyChanged();
                }
            } 
        }

        public string Error => "";

        public string this[string columnName]
        {
            get
            {
                if (columnName.Equals(nameof(Name)) && string.IsNullOrEmpty(Name))
                    return "The name of the street should not be empty";

                return null;
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
