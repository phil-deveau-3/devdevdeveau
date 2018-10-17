using System;

namespace TimeBox.ViewModels
{
    public class FiveMinuteTimerDuration : TimerDuration
    {
        public override TimeSpan Duration => TimeSpan.FromMinutes(5);
    }
}