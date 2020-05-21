using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardTest.Misc
{
    public class RelayCommand : ICommand
    {
        private Action<object> executedAction;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> action)
        {
            executedAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter = null)
        {
            executedAction?.Invoke(parameter);
        }
    }
}
