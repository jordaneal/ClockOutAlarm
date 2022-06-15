using System;
using System.ComponentModel;
using Xamarin.Forms;
using ClockOutAlarm.Views;
using System.Reflection;
using System.IO;

namespace ClockOutAlarm.ViewModels
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        private DateTime _dateTime;
        public event PropertyChangedEventHandler PropertyChanged;

        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }
        public DateTime DateTime
        {
            set
            {
                if (_dateTime != value)
                {
                    _dateTime = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
                }
            }
            get
            {
                if (HomePage.IsToggled &&
                    _dateTime.TimeOfDay.Hours == HomePage.AlarmTime.Hour &&
                    _dateTime.TimeOfDay.Minutes == HomePage.AlarmTime.Minute &&
                    _dateTime.TimeOfDay.Seconds == HomePage.AlarmTime.Second)
                    Play();
                return _dateTime;
            }
        }
        private void Play()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("ClockOutAlarm.Resources.jobDone.mp3");
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(audioStream);
            audio.Play();
        }
    }
}
