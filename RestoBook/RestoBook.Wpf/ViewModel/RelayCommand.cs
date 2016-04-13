using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestoBook.ViewModel
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> actionAexecuter;
        private readonly Predicate<object> predicate;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> action)
            : this(action,null)
        {
        }

        public RelayCommand(Action<object> action,Predicate<object> predicate)
        {
            this.actionAexecuter = action;
            this.predicate = predicate;
        }

        public bool CanExecute(object parameter)
        {
            if(parameter == null)
            {
                return true;
            }
            return predicate(parameter);
        }

        public void Execute(object parameter)
        {
            actionAexecuter(parameter);
        }
    }
}
