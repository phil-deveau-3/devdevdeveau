using System;

namespace TimeBox.ViewModels
{
    public abstract class TimerDuration
    {
        public abstract TimeSpan Duration { get; }
    }
}