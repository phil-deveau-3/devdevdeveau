using System;
using System.Windows.Input;

namespace TimeBox.ViewModels
{
    public class ResetTimerCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is CountdownTimer timer)
            {
                timer.Stop();
                timer.Clear();
                timer.Start();
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}