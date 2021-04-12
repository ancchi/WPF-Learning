using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ValidationHandling
{
    public class MainWindowViewModelWithErrorInfo : INotifyPropertyChanged, IDataErrorInfo
    {
        public MainWindowViewModelWithErrorInfo()
        {
            firstname = "Hans-Peter";
            lastname = "Schmidt";
            city = "Berlin";
            Street.Name = "Alexanderplatz";
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private string firstname;

        public string FirstName
        {
            get => firstname; // IDataErrorInfo setzt nach der Ausführung des Setters und vor der Ausführung des Getters ein. Der Wert von "firstname" wird dabei validiert.
            set
            {
                if (!string.Equals(firstname, value))
                {
                    firstname = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string lastname;

        public string LastName
        {
            get => lastname;
            set
         {
                if (!string.Equals(lastname, value))
                {
                    lastname = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string city;

        public string City
        {
            get => city;
            set
            {
                if (!string.Equals(city, value))
                {
                    city = value;
                    RaisePropertyChanged();
                }
            }
        }

        
        private Street street;

        public Street Street
        {
            get => street ??= new StreetWithNotification();
            /* entspricht:
              get {
                    return street = street ?? new StreetWithNotification();
                  }
            // ?? ist der "NULL-Zusammenfügungsoperator"
            // ??= ist der "NULL-Sammelzuweisungsoperator"
            // gibt den linken Operanden zurück, wenn dieser nicht null ist, ansonsten den rechten Operanden
            */
            set
            {
                if (street != value)
                {
                    street = value;
                    RaisePropertyChanged();
                }
            }
        }

        // Syntax: Expression Bodied Member (since C#6.0):
        public string Error => string.Empty; // Error: Eigenschaft von IDataErrorInfo; ruft eine Fehlermeldung ab, die den Fehler in diesem Objekt angibt

        // ist the same as

        /*public string Error {
            get { return string.Empty; }
        }*/


        // Item[String]: Eigenschaft von IDataErrorInfo; Ruft die Fehlermeldung für die Eigenschaft mit dem angegebenen Namen ab.
        public string this[string columnName] // ruft die Fehlermeldung für die Eigenschaft ab, die an die Textbox gebunden ist, z.B. "LastName" in <Textbox Text={Binding LastName ...} ... />
            // die Ermittlung der columnName mit "this" ist möglich, weil diese Klasse von IDataErrorInfo abstammt
        {
            get
            {
                if (columnName.Equals(nameof(LastName)) &&
                    string.IsNullOrEmpty(LastName))
                {
                    return "The LastName should not be empty";
                }

                if (columnName.Equals(nameof(City)) &&
                    string.IsNullOrEmpty(City))
                {
                    return "The City should not be empty";
                }

                return String.Empty;
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
