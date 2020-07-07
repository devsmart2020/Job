using System;
using System.Windows.Input;

namespace Meteoro.ViewModels.BaseViewModel
{
    public class Command : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canexecuteMethod;

        public Command(Action<object> executeMethod, Func<object, bool> canexecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canexecuteMethod = canexecuteMethod;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }


        public event EventHandler CanExecuteChanged;

    }
}
