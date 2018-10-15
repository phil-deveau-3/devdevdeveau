using System;
using System.Windows;
using System.Windows.Input;

namespace TimeBox.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public string TimeRemaining { get; set; }
        public CountdownTimer Timer { get; }
        public double Percentage { get; set; }

        public ICommand StartTimerCommand { get; }
        public ICommand StopTimerCommand { get; }
        public ICommand ResetTimerCommand { get; }
        public ICommand QuitCommand { get; }
        public ICommand AddOneMinuteCommand { get; }
        public ICommand AddFiveMinutesCommand { get; }
        public ICommand AddTenMinutesCommand { get; }

        public MainWindowViewModel()
        {
            StartTimerCommand = new StartTimerCommand();
            ResetTimerCommand = new ResetTimerCommand();
            StopTimerCommand = new StopTimerCommand();
            QuitCommand = new QuitCommand();
            AddOneMinuteCommand = new AddOneMinuteCommand();
            AddFiveMinutesCommand = new AddFiveMinutesCommand();
            AddTenMinutesCommand = new AddTenMinutesCommand();

            var timespan = TimeSpan.FromMinutes(5);
            TimeRemaining = timespan.ToString(@"hh\:mm\:ss");
            Percentage = 100d;

            Timer = new CountdownTimer(timespan);

            Timer.Elapsed += (sender, args) =>
            {
                if (!(sender is CountdownTimer timer)) return;
                var timeRemaining = timer.TimeRemaining();

                if (timeRemaining.TotalMilliseconds >= 0)
                {
                    TimeRemaining = timer.TimeRemaining().ToString(@"hh\:mm\:ss");
                    Percentage = timer.PercentRemaining;
                }
                else
                {
                    TimeRemaining = "00:00:00";
                    Percentage = 0d;
                    StopTimerCommand.Execute(Timer);
                }

                OnPropertyChanged(nameof(TimeRemaining));
                OnPropertyChanged(nameof(Percentage));
            };
        }
    }

    public class QuitCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }

        public event EventHandler CanExecuteChanged;
    }

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

    public class AddOneMinuteCommand : AddTimeCommand
    {
        public AddOneMinuteCommand() : base(TimeSpan.FromMinutes(1))
        {
            
        }
    }

    public class AddFiveMinutesCommand : AddTimeCommand
    {
        public AddFiveMinutesCommand() : base(TimeSpan.FromMinutes(5))
        {
        }
    }

    public class AddTenMinutesCommand : AddTimeCommand
    {
        public AddTenMinutesCommand() : base(TimeSpan.FromMinutes(10))
        {
            
        }
    }

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