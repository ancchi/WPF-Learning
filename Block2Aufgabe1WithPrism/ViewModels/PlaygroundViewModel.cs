using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Block2WithPrism.ViewModels {
    class PlaygroundViewModel : BindableBase, IDataErrorInfo {

        private string txtInTextBox = string.Empty;
        private string selectedComboboxItem = string.Empty;
        private string newComboboxItem = string.Empty;
        private ObservableCollection<string> comboBoxListe = new ObservableCollection<string> { "Bleistift", "Kugelschreiber", "Radiergummi" };
        
        public DelegateCommand AddItemToComboBoxCommand { get; private set; }
        public DelegateCommand DeleteSelectedItemCommand { get; private set; }
        public PlaygroundViewModel() {
            AddItemToComboBoxCommand = new DelegateCommand(Submit, CanSubmit);
            DeleteSelectedItemCommand = new DelegateCommand(Delete, CanDelete);
        }


        private void Submit() {
            ComboBoxListe.Add(NewComboboxItem);
            NewComboboxItem = string.Empty;
        }

        private bool CanSubmit() {
            // wegen Trim() muss mit "?" sichergestellt werden, dass Trim() gar nicht ausgeführt wird, wenn NewComboboxItem null ist
            return !(string.IsNullOrEmpty(NewComboboxItem?.Trim())) 
                && !ComboBoxListe.Contains(NewComboboxItem);
        }

        private void Delete() {
            ComboBoxListe.Remove(SelectedComboboxItem);
        }

        private bool CanDelete() {
            return !(string.IsNullOrEmpty(SelectedComboboxItem));
        }

        public string TxtInTextBox {
            get => txtInTextBox;
            set => SetProperty(ref txtInTextBox, value); // SetProperty(...) prüft auch gleich, ob der Wert in der TextBox sich wirklich geändert hat;
                                                         // man kann als drittes Argument den PropertyName mitgeben
                                                         // das Event "Propertychanged" wird ebenfalls automatisch ausgelöst
        }

        public string SelectedComboboxItem {
            get => selectedComboboxItem;
            set {
                SetProperty(ref selectedComboboxItem, value);
                DeleteSelectedItemCommand.RaiseCanExecuteChanged();
            }
        }

        public string NewComboboxItem {
            get => newComboboxItem ??= string.Empty;
            set {
                SetProperty(ref newComboboxItem, value);
                AddItemToComboBoxCommand.RaiseCanExecuteChanged();
                // TODO disable Button, wenn Error vorhanden
            }
        }

        public ObservableCollection<string> ComboBoxListe {
            get => comboBoxListe;
            set => SetProperty(ref comboBoxListe, value);
        }

        // Error Handling

        public string Error => string.Empty;
        int allowedSignNumber = 15;

        public string this[string columnName] {
            get {
                if (columnName.Equals(nameof(NewComboboxItem)) && NewComboboxItem.Length > allowedSignNumber) {
                    return $"Der neue Eintrag darf nicht mehr als {allowedSignNumber} Zeichen haben.";
                }
                return string.Empty;
            }
        }
    }
}
