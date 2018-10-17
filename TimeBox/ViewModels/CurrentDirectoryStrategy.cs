using System;
using System.IO;
using System.Windows.Media;

namespace TimeBox.ViewModels
{
    public class CurrentDirectoryStrategy : AlarmStrategy
    {
        private readonly MediaPlayer _mediaPlayer;

        public CurrentDirectoryStrategy(MediaPlayer mediaPlayer)
        {
            _mediaPlayer = mediaPlayer;
        }

        public override AlarmState HandleAlarm()
        {
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "timeup.mp3"))) return AlarmState.Unhandled;

            _mediaPlayer.Dispatcher.Invoke(() =>
            {
                _mediaPlayer.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "timeup.mp3")));
                _mediaPlayer.Play();
            });

            return AlarmState.Handled;

        }
    }
}