using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClockOutAlarm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public static bool IsToggled { get; private set; }
        public static DateTime AlarmTime { get; set; }
        public HomePage()
        {
            InitializeComponent();
        }
        void Handle_Toggled(object sender, ToggledEventArgs e)
        {
            IsToggled = e.Value;
        }
        void OnTimePickerPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                AlarmTime = DateTime.Today + _timePicker.Time;
            }
        }
    }
}