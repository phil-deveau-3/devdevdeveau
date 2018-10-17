namespace TimeBox.ViewModels
{
    public abstract class AlarmStrategy
    {
        public abstract AlarmState HandleAlarm();
    }
}