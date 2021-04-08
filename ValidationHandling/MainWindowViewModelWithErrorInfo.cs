using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            get => firstname;
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
            set
            {
                if (street != value)
                {
                    street = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Error => string.Empty;

        public string this[string columnName]
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
