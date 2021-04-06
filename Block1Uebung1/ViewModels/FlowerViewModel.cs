using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Block1Uebung1.Models;


namespace Block1Uebung1.ViewModels {
    class FlowerViewModel : INotifyPropertyChanged {

        ObservableCollection<Flower> flowers = new ObservableCollection<Flower>();
        ObservableCollection<Flower> unfilteredFlowerList = new ObservableCollection<Flower>();
        

        public FlowerViewModel() {
            LoadFlowers();
            // DeleteCommand ist eine Instanz von MyIcommand; ich kann sie mit dem Konstruktor initialisieren,
            // der eine Action und eine Func<bool> entgegennimmt
           
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
        }

        public ObservableCollection<Flower> Flowers {
            get {
                return flowers;
            }
            set {
                flowers = value;
                RaisePropertyChanged();
            }
        }

        private void LoadFlowers() {

            flowers.Add(new Flower { NameOfFlower = "Rose" });
            flowers.Add(new Flower { NameOfFlower = "Akelei" });
            flowers.Add(new Flower { NameOfFlower = "Tulpe" });
            flowers.Add(new Flower { NameOfFlower = "Lilie" });
            flowers.Add(new Flower { NameOfFlower = "Lotus" });
            flowers.Add(new Flower { NameOfFlower = "Amaryllis" });
            flowers.Add(new Flower { NameOfFlower = "Euphorbia" });
            flowers.Add(new Flower { NameOfFlower = "Fetthenne" });
            flowers.Add(new Flower { NameOfFlower = "Gloriosa" });
            flowers.Add(new Flower { NameOfFlower = "Inkalilie" });
            flowers.Add(new Flower { NameOfFlower = "Zauberglöckchen" });
            flowers.Add(new Flower { NameOfFlower = "Iris" });

            unfilteredFlowerList = flowers;
            Flowers = flowers;
        }

        public MyICommand DeleteCommand {
            get;
            set;
        }

        // Element löschen

        private void OnDelete() {
            Flowers.Remove(SelectedFlower);
        }

        private bool CanDelete() {
            return SelectedFlower != null;
        }

        private Flower _selectedFlower;

        public Flower SelectedFlower {
            get {
                return _selectedFlower;
            }
            set {
                _selectedFlower = value;
                DeleteCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
         
        // Element hinzufügen

        public MyICommand AddCommand {
            get;
            set;
        }

        private void OnAdd() {
            bool exists = false;
            foreach (Flower flower in Flowers) {
                if(flower.NameOfFlower.Equals(_enteredFlower)) {
                    exists = true;
                    break;
                }
            }
            if (!exists) {
                Flowers.Add(new Flower { NameOfFlower = _enteredFlower });
                EnteredFlower = string.Empty;
            }
        }

        private bool CanAdd() {
            return !(string.IsNullOrEmpty(EnteredFlower));
        }

        private string _enteredFlower;

        public string EnteredFlower {
            get {
                return _enteredFlower;
            }
            set {
                _enteredFlower = value;
                AddCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        // Liste nach Anfangsbuchstaben filtern

        private string[] _myAlphabet = {"Alle", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                                        "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public string[] MyAlphabet {
            get {
                return _myAlphabet;
            }
        }

        string _selectedLetter;  

        public string SelectedLetter {
            get {
                return _selectedLetter;
            }
            set {
                if(_selectedLetter != value) {
                    _selectedLetter = value;
                    ShowFlowersWithLetter(_selectedLetter);
                }
            }     
        }


        private void ShowFlowersWithLetter(string selectedLetter) {

            ObservableCollection<Flower> filteredFlowers = new ObservableCollection<Flower>();
            Flowers = unfilteredFlowerList;

            if (!selectedLetter.Equals("Alle")) {
                foreach (Flower flower in Flowers) {
                    if (flower.NameOfFlower.StartsWith(selectedLetter)) {
                        filteredFlowers.Add(flower);
                    }
                }
                Flowers = filteredFlowers;
            } else {
                Flowers = unfilteredFlowerList;
            }
            RaisePropertyChanged(nameof(Flowers));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
