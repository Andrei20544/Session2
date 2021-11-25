using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Session2.ViewModels
{
    public class DelegateCommands : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public event EventHandler CanExecuteChange
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object param)
        {
            if (_canExecute != null) return _canExecute(param);
            return true;
        }

        public void Execute(object param)
        {
            if (_execute != null) _execute(param);
        }

        public DelegateCommands(Action<object> executeAction) : this(executeAction, null) { }
        public DelegateCommands(Action<object> executeAction, Func<object, bool> canExecute)
        {
            _execute = executeAction;
            _canExecute = canExecute;
        }
    }
}
