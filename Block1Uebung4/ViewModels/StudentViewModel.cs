using Block1Uebung4.Converters;
using Block1Uebung4.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Block1Uebung4.ViewModels {

    class StudentViewModel : INotifyPropertyChanged {

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

        private string studentName;

        public string StudentName
        {
            get => studentName;
            set
            {
                // Die Änderung soll nur ausgelöst werden, wenn sich der Wert tatsächlich geändert hat.
                if (!string.Equals(studentName, value))
                {
                    studentName = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Wird aufgerufen, wenn sich hier eine Eigenschaft geändert hat
        /// </summary>
        /// <param name="args"></param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            // Uns interessiert nur die Änderung des Wertes für StudentName
            if (string.Equals(args.PropertyName, nameof(StudentName)))
            {

                var typeConverter = TypeDescriptor.GetConverter(typeof(Student));

                if (typeConverter == null)
                {
                    return;
                }

                // Überprüfen, ob die Zeichenkette umgewandelt werden kann
                if (typeConverter.CanConvertFrom(typeof(string)))
                {
                    // umwandeln
                    var newStudent = typeConverter.ConvertFrom(StudentName) as Student;

                    // wenn ein Ergebnis vorliegt
                    if (newStudent != null)
                    {
                        // der Liste hinzufügen
                        students.Add(newStudent);

                        // und markieren
                        Student = newStudent; 
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
