using System;
using System.ComponentModel;
using System.Windows;

namespace Block1Uebung1.VML {
    class ViewModelLocator {

        /* der ViewModelLocator findet anhand des in XAML eingebundenden Views die passende ViewModel-Klasse und 
         * initialisert mit ihnen den gebrauchten DataContext */

        public static bool GetAutoHookedUpViewModel(DependencyObject obj) {
            return (bool)obj.GetValue(AutoHookedUpViewModelProperty);
        }

        public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value) {
            obj.SetValue(AutoHookedUpViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoHookedUpViewModelProperty =
            DependencyProperty.RegisterAttached("AutoHookedUpViewModel", typeof(bool), typeof(ViewModelLocator),
                new PropertyMetadata(false, AutoHookedUpViewModelChanged));

        private static void AutoHookedUpViewModelChanged(DependencyObject dependObj, DependencyPropertyChangedEventArgs e) {
            // DependencyObject dependObj enthält den View, in dem "AutoHookedUpViewModel" mit "True" aktiviert wurde
            if (DesignerProperties.GetIsInDesignMode(dependObj)) return;
            var viewType = dependObj.GetType(); // Name des Views

            string str = viewType.FullName; // gibt den FullyQualified Name des Typs zurück
            str = str.Replace(".Views.", ".ViewModels."); // der Pfad zu ViewModel-Ordner wird "gebaut" - zuerst der Namespace

            var viewTypeName = str; // Pfad enthält immer noch den View als File-Name
            var viewModelTypeName = viewTypeName + "Model"; // das ändert sich mit dem Hinzufügen von "Model" -> ...ViewModel
            var viewModelType = Type.GetType(viewModelTypeName); // der Typ ...ViewModel wird geschaffen
            var viewModel = Activator.CreateInstance(viewModelType); // Activator.CreateInstance erstellt eine Instanz für diesen Typ und speichert ihn in viewModel

            ((FrameworkElement)dependObj).DataContext = viewModel; // hier wird dann letztendlich der Datenkontext angegeben
            // ersetzt sozusagen ...View().DataContext = new ...ViewModel();
        }

    }
}
