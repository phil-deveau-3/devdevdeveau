using System;
using System.Windows.Input;
using System.Windows.Media;

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

            var mediaPlayer = new MediaPlayer();
            AlarmStrategy alarm = new Alarm(new CurrentDirectoryStrategy(mediaPlayer),
                new MyMusicAlarmStrategy(mediaPlayer), new SystemBeepAlarmStrategy());
            
            //TODO: Get timespan from elsewhere
            var timespan = TimeSpan.FromMinutes(5);
            TimeRemaining = timespan.ToString(@"hh\:mm\:ss");
            Percentage = 100d;

            Timer = new CountdownTimer(new FiveMinuteTimerDuration());

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
                    alarm.HandleAlarm();
                }

                OnPropertyChanged(nameof(TimeRemaining));
                OnPropertyChanged(nameof(Percentage));
            };
        }
    }
}