using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            get => base.Name;
            set
            {
                if (!string.Equals(base.Name, value))
                {
                    base.Name = value;
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
