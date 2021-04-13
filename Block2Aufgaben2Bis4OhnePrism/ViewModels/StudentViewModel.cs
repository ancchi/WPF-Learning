using Block2Aufgaben2Bis4OhnePrism.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Block2Aufgaben2Bis4OhnePrism.ViewModels {
    class StudentViewModel : INotifyPropertyChanged, IDataErrorInfo {

        
        public MyICommand AddStudentToList { get; private set; }
        public StudentViewModel() {
            GenerateInitialStudentList();
            AddStudentToList = new MyICommand(AddStudent, CanAddStudent);
            PropertyChanged += OnPropertyChanged;
        }

        public void AddStudent() {
            studentList.Add(NewStudent);
        }

        public bool CanAddStudent() {
            return (NewStudent != null);
        }

        public ObservableCollection<Student> studentList = new(); // vereinfacht für new ObservableCollection<Student>()
        public ObservableCollection<Student> StudentList {
            get;
            set;
        }

        private Student newStudent;
        public Student NewStudent {
            get => newStudent;
            set {
                if (!newStudent.Equals(value)) {
                    newStudent = value;
                    RaisePropertyChanged();
                    AddStudentToList.RaiseCanExecuteChanged();
                }
            }
        }


        private string newStudentInputString = string.Empty;

        public string NewStudentInputString {
            get => newStudentInputString;
            set {
                if (!string.Equals(newStudentInputString, value)) {
                    
                    newStudentInputString = value;
                    
                    RaisePropertyChanged();
                    AddStudentToList.RaiseCanExecuteChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args) {

            if (string.Equals(args.PropertyName, nameof(NewStudentInputString))) {

                var typeConverter = TypeDescriptor.GetConverter(typeof(Student));

                if (typeConverter == null) {
                    return;
                }

                if (typeConverter.CanConvertFrom(typeof(string))) {
                    newStudent = typeConverter.ConvertFrom(NewStudentInputString) as Student;
                }
            }
        }

        public string Error => string.Empty;

        public string this[string columnName] {
            get {
                if (columnName.Equals(nameof(NewStudentInputString))) && NewStudent == null) {
                    return "Das Format für einen neuen Eintrag ist 'Nachname, Vorname, Anwesend/Nicht anwesend'";
                }
                return string.Empty;
            }
        }

        private void GenerateInitialStudentList() {
            studentList.Add(new Student { PreName = "Anika", LastName = "Langer", IstAnwesend = true});
            studentList.Add(new Student { PreName = "Fritz", LastName = "Bode", IstAnwesend = true});
            studentList.Add(new Student { PreName = "Isabella Lisa", LastName = "Parker", IstAnwesend = true});

            StudentList = studentList;
        }
    }
}
