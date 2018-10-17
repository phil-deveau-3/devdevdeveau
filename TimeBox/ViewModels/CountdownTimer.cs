
using System;
using System.Timers;

namespace TimeBox.ViewModels
{
    public class CountdownTimer : Timer
    {
        private TimeSpan _countdown;
        private DateTime _lastTick;
        private double _timeRemaining;

        public double PercentRemaining => _timeRemaining / _countdown.TotalMilliseconds * 100;

        public CountdownTimer(TimerDuration duration) : base(1.0d)
        {
            _countdown = duration.Duration;
            _timeRemaining = duration.Duration.TotalMilliseconds;
            Elapsed += CountdownTimer_Elapsed;
        }

        private void CountdownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeRemaining -= e.SignalTime.Subtract(_lastTick).TotalMilliseconds;
            _lastTick = e.SignalTime;
        }

        public TimeSpan TimeRemaining()
        {
            return TimeSpan.FromMilliseconds(_timeRemaining);
        }

        public void AddTime(TimeSpan timespan)
        {
            _countdown = _countdown.Add(timespan);
            _timeRemaining += timespan.TotalMilliseconds;
        }

        public new void Start()
        {
            _lastTick = DateTime.Now;
            base.Start();
        }

        public new void Stop()
        {
            base.Stop();
        }

        public void Reset()
        {
            Stop();
            _timeRemaining = _countdown.TotalMilliseconds;
        }

        public void Clear()
        {
            _countdown = TimeSpan.FromMinutes(0);
            _timeRemaining = 0;
        }
    }

    public delegate void CountdownTimerUpdatedHandler(object sender, CountdownTimerUpdatedEventArgs e);

    public class CountdownTimerUpdatedEventArgs:EventArgs
    {
        public TimeSpan TimeRemaining { get; }
        public double PercentageComplete { get; }

        public CountdownTimerUpdatedEventArgs(TimeSpan timeRemaining, double percentageComplete)
        {
            TimeRemaining = timeRemaining;
            PercentageComplete = percentageComplete;
        }
    }
}
