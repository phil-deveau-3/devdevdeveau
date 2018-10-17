﻿using System;
using System.IO;
using System.Windows.Media;

namespace TimeBox.ViewModels
{
    public class MyMusicAlarmStrategy : AlarmStrategy
    {
        private readonly MediaPlayer _mediaPlayer;
        private string _path;

        public MyMusicAlarmStrategy(MediaPlayer mediaPlayer)
        {
            _mediaPlayer = mediaPlayer;
            _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "timebox.mp3");
        }

        public override AlarmState HandleAlarm()
        {
            if (!File.Exists(_path))
                return AlarmState.Unhandled;

            _mediaPlayer.Dispatcher.Invoke(() =>
            {
                _mediaPlayer.Open(new Uri(_path));
                _mediaPlayer.Play();
            });

            return AlarmState.Handled;

        }
    }
}