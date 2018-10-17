using System;
using System.Windows.Input;

namespace TimeBox.ViewModels
{
    public abstract class AddTimeCommand : ICommand
    {
        private readonly TimeSpan _timeToAdd;

        protected AddTimeCommand(TimeSpan timeToAdd)
        {
            _timeToAdd = timeToAdd;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is CountdownTimer timer)
            {
                timer.Stop();
                timer.AddTime(_timeToAdd);
                timer.Start();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}