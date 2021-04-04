using System;
using System.Windows.Input;

namespace Block1Uebung1 {
    class MyICommand : ICommand {
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        /* 
         * 2 Konstruktoren
         * Einer nimmt direkt den Befehl an, der andere nimmt eine Prüfung, ob der Befehl ausgeführt werden kann UND den Befehl an
         */

        public MyICommand(Action executeMethod) {
            _TargetExecuteMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod) {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        bool ICommand.CanExecute(object parameter) {
            if (_TargetCanExecuteMethod != null) {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null) {
                return true;
            }

            return false;
        }

        void ICommand.Execute(object parameter) {
            if (_TargetExecuteMethod != null) {
                _TargetExecuteMethod();
            }
        }

        // das Event, dass etwas "selected" wurde, wird hier empfangen und an den Datenkontext weitergegeben
        // EventArgs.Empty -> keine Event-Daten
        public event EventHandler CanExecuteChanged = delegate { };
        public void RaiseCanExecuteChanged() {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
