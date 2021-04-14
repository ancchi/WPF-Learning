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
            NewStudentInputString = string.Empty;
        }

        bool isStudentInList = false;
        public bool CanAddStudent() {
            isStudentInList = false;
            if (NewStudent != null) {
                foreach (Student student in StudentList) {
                    if (NewStudent.PreName.Equals(student.PreName) && NewStudent.LastName.Equals(student.LastName)) {
                        isStudentInList = true;
                        break;
                    }
                }
            }
            return (NewStudent != null && !isStudentInList);
        }

        public ObservableCollection<Student> studentList = new(); // vereinfacht für new ObservableCollection<Student>()
        public ObservableCollection<Student> StudentList {
            get;
            set;
        }

        private Student newStudent = new Student();
        public Student NewStudent {
            get => newStudent;
            set {
                if (!(newStudent.PreName.Equals(value.PreName) && newStudent.LastName.Equals(value.LastName))) {
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

        private Student selectedStudent;

        public Student SelectedStudent {
            get => selectedStudent;
            set {
                selectedStudent = value;
                RaisePropertyChanged();
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

                    if (newStudent != null) {
                        NewStudent = newStudent;
                    }
                    
                }
            }
        }

        public string Error => string.Empty;

        public string this[string columnName] { // TODO diese Property wird aus irgendeinem Grund nicht aufgerufen!
            get {
                string message = string.Empty;

                if (columnName.Equals(nameof(NewStudentInputString)) && !string.IsNullOrEmpty(NewStudentInputString)) { // keine Validierung, wenn Textbox leer
                    if (isStudentInList) {
                        message = "Dieser Student wurde bereits in die Liste aufgenommen.";
                    } else if (NewStudent == null) {
                        message = "Das Format für einen neuen Eintrag ist 'Nachname, Vorname, Anwesend/Nicht anwesend'";
                    }
                } 
                return message;
            }
        }

        private void GenerateInitialStudentList() {
            studentList.Add(new Student { PreName = "Anika", LastName = "Langer", IstAnwesend = true});
            studentList.Add(new Student { PreName = "Fritz", LastName = "Bode", IstAnwesend = false});
            studentList.Add(new Student { PreName = "Isabella Lisa", LastName = "Parker", IstAnwesend = true});

            StudentList = studentList;
        }
    }
}
