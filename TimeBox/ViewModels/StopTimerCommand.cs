using System;
using System.Windows.Input;

namespace TimeBox.ViewModels
{
    public class StopTimerCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is CountdownTimer timer) timer.Stop();
        }

        public event EventHandler CanExecuteChanged;
    }
}