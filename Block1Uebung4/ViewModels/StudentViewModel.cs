﻿using Block1Uebung4.Converters;
using Block1Uebung4.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Block1Uebung4.ViewModels {

    [TypeConverter(typeof(BooleanToColorTypeConverter))]
    class StudentViewModel : INotifyPropertyChanged {

        public StudentViewModel() {
            fillStudentList();
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
