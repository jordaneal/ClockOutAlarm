using ClockOutAlarm.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ClockOutAlarm
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}
