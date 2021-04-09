using Block1Uebung4.Converters;
using Block1Uebung4.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;


namespace Block1Uebung4.ViewModels {

    class StudentViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public StudentViewModel() {
            fillStudentList();

            // Wir hören hier selbst auf das Ereignis, wenn sich der Wert einer Eigenschaft ändert
            // Das ist zwar so nicht notwendig, wir können so den Code aber besser strukturieren

            this.PropertyChanged += OnPropertyChanged;
        }

        public ObservableCollection<Student> students = new ObservableCollection<Student>();

        public ObservableCollection<Student> Students {
            get;
            set;
        }

        private Student student;
        
        public Student Student {
            get => student;
            set {
                student = value;
                RaisePropertyChanged();
            }
        }

       
        private string student_anwesend;
        
        public string Student_Anwesend {
            get => student_anwesend;
            set {
                // Die Änderung soll nur ausgelöst werden, wenn sich der Wert tatsächlich geändert hat.
                if (!string.Equals(student_anwesend, value)) {
                    student_anwesend = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Student studentEntry;

        public Student StudentEntry {
            get => studentEntry;
            set {
                studentEntry = value;
                RaisePropertyChanged();
            }
        }

        private SolidColorBrush colorBrush;

        public SolidColorBrush ColorBrush {
            get => colorBrush;
            set {
                colorBrush = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); // von hier weiter in "OnPropertyChanged(...)"
        }

        /// <summary>
        /// Wird aufgerufen, wenn sich hier eine Eigenschaft geändert hat
        /// </summary>
        /// <param name="args"></param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args) {
            // StudentTypeConverter
            // Uns interessiert nur die Änderung des Wertes für StudentName
            /*if (string.Equals(args.PropertyName, nameof(Student_Anwesend))) {

                var typeConverter = TypeDescriptor.GetConverter(typeof(Student));

                if (typeConverter == null) {
                    return;
                }

                // Überprüfen, ob die Zeichenkette umgewandelt werden kann
                if (typeConverter.CanConvertFrom(typeof(string))) {
                    // umwandeln
                    Student newStudent = typeConverter.ConvertFrom(Student_Anwesend) as Student;

                    // wenn ein Ergebnis vorliegt
                    if (newStudent != null) {
                        // der Liste hinzufügen
                        students.Add(newStudent);

                        // und markieren
                        Student = newStudent;
                    }
                }
            }*/

            // StudentToColorTypeConverter
            if (string.Equals(args.PropertyName, nameof(StudentEntry))) {

                var typeConverter = TypeDescriptor.GetConverter(typeof(Student));

                if (typeConverter == null) {
                    return;
                }

                if (typeConverter.CanConvertFrom(typeof(string))) {

                    string studentString = StudentEntry.ToString();

                    SolidColorBrush color = (SolidColorBrush)typeConverter.ConvertFrom(studentString);

                    if (color != null) {
                        ColorBrush = color;
                    }
                }
            }
        }

        private void fillStudentList() {
            students.Add(new Student { Name = "Lisa", IstAnwesend = true });
            students.Add(new Student { Name = "Bart", IstAnwesend = false });
            students.Add(new Student { Name = "Maggie", IstAnwesend = false });
            students.Add(new Student { Name = "Snowball", IstAnwesend = true });
            students.Add(new Student { Name = "Knecht Ruprecht", IstAnwesend = false });
            students.Add(new Student { Name = "Homer", IstAnwesend = false });
            students.Add(new Student { Name = "Marge", IstAnwesend = true });

            Students = students;
        }
    }
}
