namespace TimeBox.ViewModels
{
    public class Alarm : AlarmStrategy
    {
        private readonly AlarmStrategy[] _alarms;

        public Alarm(params AlarmStrategy[] alarms)
        {
            _alarms = alarms;
        }
        
        public override AlarmState HandleAlarm()
        {
            foreach (var alarm in _alarms)
            {
                var state = alarm.HandleAlarm();
                if (state == AlarmState.Handled) return state;
            }

            return AlarmState.Unhandled;
        }
    }
}