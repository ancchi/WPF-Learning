using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Muster__ohne_Prism_.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;

        public MainWindowViewModel()
        {

        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (!string.Equals(firstName, value))
                {
                    firstName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (!string.Equals(lastName, value))
                {
                    lastName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
