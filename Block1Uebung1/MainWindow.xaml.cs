using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/* 
 Aufgabe Block 1, Übung 1:
Erstelle eine WPF Anwendung mit einer MVVM Anwendungsarchitektur, besteht aus einem Hauptfenster und einem dazugehörendem Model. 
Im Hauptfenster gibt es folgende Steuerelemente: Text, ListBox, ComboBox und zwei Buttons. Jedes dieser Steuerelemente bekommt 
seine Daten über Binding (welche Daten ist egal). Die Aktion, die bei Clicks auf die Buttons ausgeführt wird, erfolgt auch über 
das dahinterliegende Model.

 */

namespace Block1Uebung1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }
}
