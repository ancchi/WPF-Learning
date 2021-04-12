using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ValidationHandling
{
    public class MainWindowViewModelWithErrorNotification : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private List<(string propertyName, string error)> errors = new List<(string, string)>();

        public MainWindowViewModelWithErrorNotification()
        {
            firstname = "Hans-Peter";
            lastname = "Schmidt";
            city = "Berlin";
            Street.Name = "Alexanderplatz";
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private string firstname;

        public string FirstName
        {
            get => firstname;
            set
            {
                if (!string.Equals(firstname, value))
                {
                    firstname = value;
                    RaisePropertyChanged();
                    Validate();
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
                    Validate();
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
                    Validate(); // wird explizit aufgerufen
                }
            }
        }

        private Street street;

        public Street Street
        {
            get => street ??= new StreetWithNotification();
            set
            {
                if (street != value)
                {
                    street = value;
                    RaisePropertyChanged();
                    Validate();
                }
            }
        }

        public bool HasErrors => errors.Any(); // Eigenschaft von INotifyDataErrorInfo; Ruft einen Wert ab der angibt, ob die Entität über Validierungsfehler verfügt.

        public IEnumerable GetErrors(string propertyName) // Methode von INotifyDataErrorInfo: Ruft die Validerungsfehler für eine angegebene Eigenschaft oder für die ganze Entität ab.
        {
            return errors.Where(t => t.propertyName.Equals(propertyName)).Select(t => t.error).ToList();
        }

        private void Validate() // selbst geschriebene Methode
        {
            errors.Clear();

            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add((nameof(LastName), "The LastName should not be empty"));
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(LastName)));
            }

            if (string.IsNullOrEmpty(City))
            {
                errors.Add((nameof(City), "The City should not be empty"));
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(City)));
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
