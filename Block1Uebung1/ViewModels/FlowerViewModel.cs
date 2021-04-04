using System.Collections.ObjectModel;
using Block1Uebung1.Models;
using System;


namespace Block1Uebung1.ViewModels {
    class FlowerViewModel {

        ObservableCollection<Flower> flowers = new ObservableCollection<Flower>();
        ObservableCollection<Flower> unfilteredFlowerList = new ObservableCollection<Flower>();
        

        public FlowerViewModel() {
            LoadFlowers();
            // DeleteCommand ist eine Instanz von MyIcommand; ich kann sie mit dem Konstruktor initialisieren,
            // der eine Action und eine Func<bool> entgegennimmt
            unfilteredFlowerList = flowers;
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            FilterCommand = new MyICommand(OnFilter, CanFilter);
        }

        public ObservableCollection<Flower> Flowers {
            get;
            set;
        }

        private void LoadFlowers() {

            flowers.Add(new Flower { NameOfFlower = "Rose" });
            flowers.Add(new Flower { NameOfFlower = "Akelei" });
            flowers.Add(new Flower { NameOfFlower = "Tulpe" });
            flowers.Add(new Flower { NameOfFlower = "Lilie" });
            flowers.Add(new Flower { NameOfFlower = "Lotus" });

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
            }
        }

        // Element hinzufügen
        public MyICommand AddCommand {
            get;
            set;
        }

        private void OnAdd() {
            Flowers.Add(new Flower { NameOfFlower = _enteredFlower });
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
            }
        }

        // Liste filtern

        // TODO 
        // Problem: die Liste in der ListBox wird nicht geupdatet; man kann mit der Combobox anscheinend keinen Command o.ä. ausführen

        private string[] _myAlphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                                        "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public string[] MyAlphabet {
            get {
                return _myAlphabet;
            }
        }

        public MyICommand FilterCommand {
            get;
            set;
        }

        string _selectedLetter;

        private void OnFilter() {
            if (_selectedLetter != null) {
                ShowFlowersWithLetter(_selectedLetter);
            }
        }

        private bool CanFilter() {
            return !(string.IsNullOrEmpty(_selectedLetter));
        }

       

        public string SelectedLetter {
            get {
                return _selectedLetter;
            }
            set {
                if(_selectedLetter != value) {
                    _selectedLetter = value;
                    FilterCommand.RaiseCanExecuteChanged();
                }
            }     
        }

        ObservableCollection<Flower> filteredFlowers = new ObservableCollection<Flower>();

        private void ShowFlowersWithLetter(string letter) {
            Flowers = unfilteredFlowerList;

            foreach (Flower flower in Flowers) {
                if(flower.NameOfFlower.StartsWith(letter)) {
                    filteredFlowers.Add(flower);
                }
            }
            Flowers = filteredFlowers;
        }
    }
}
