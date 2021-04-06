using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Muster__mit_Prism_.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string firstName;
        private string lastName;

        public MainWindowViewModel()
        {

        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }


    }
}
