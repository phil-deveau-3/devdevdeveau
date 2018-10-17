using System;
using System.Windows.Input;

namespace TimeBox.ViewModels
{
    public class StartTimerCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is CountdownTimer timer) timer.Start();
        }

        public event EventHandler CanExecuteChanged;
    }
}