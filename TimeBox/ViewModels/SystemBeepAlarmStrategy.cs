using System.Media;

namespace TimeBox.ViewModels
{
    public class SystemBeepAlarmStrategy : AlarmStrategy
    {
        public override AlarmState HandleAlarm()
        {
            SystemSounds.Exclamation.Play();
            return AlarmState.Handled;
        }
    }
}