using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyLayoutPlayground.Models;

namespace MyLayoutPlayground.ViewModels {
    class StudentViewModel : INotifyPropertyChanged {

        public StudentViewModel() {
            generateStudentList();
        }

        private Student student;

        private Student Student {
            get => student ??= new Student();
            set {
                if(!string.Equals(student, value)) {
                    student = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<Student> studentList = new();

        public ObservableCollection<Student> StudentList {
            get => studentList;
            set {
                if (studentList != value) {
                    studentList = value;
                    RaisePropertyChanged();
                }
            }
        }

        string path = "/images/";

        public void generateStudentList() {
            studentList.Add(new Student { PreName = "Lissy", LastName = "Baumann", ImgPath = path + "Baer.jpg" });
            studentList.Add(new Student { PreName = "Mark", LastName = "Ficus", ImgPath = path + "Hund.jpg" });
            studentList.Add(new Student { PreName = "John", LastName = "Sander", ImgPath = path + "Panda.jpg" });
            studentList.Add(new Student { PreName = "Clara", LastName = "See", ImgPath = path + "Schaf.jpg" });
            studentList.Add(new Student { PreName = "Sibirius", LastName = "Waystine", ImgPath = path + "Ziege.jpg" });

            StudentList = studentList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
