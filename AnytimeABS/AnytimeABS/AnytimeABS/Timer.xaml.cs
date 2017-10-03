using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnytimeABS.Messages;

namespace AnytimeABS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer : ContentPage
	{
		public Timer ()
		{
			InitializeComponent ();

            //Wiring up XAML buttons
            StartTimer.Clicked += (s, e) =>
            {
                var message = new StartTimerTaskMessage();
                MessagingCenter.Send(message, "StartTimerTaskMessage");
            };

            StopTimer.Clicked += (s, e) =>
            {
                var message = new StopTimerTaskMessage();
                MessagingCenter.Send(message, "StopTimerTaskMessage");
            };




            var minutes = TimeSpan.FromMinutes(1)
            /*Device.StartTimer(minutes, async () =>
           {
               Start_Timer();
               return false;
           });*/
		}

        private void Stop_Timer_Button_Clicked(object sender, EventArgs e)
        {
            //ToDo: Kill the timer & notification process
            Navigation.PopAsync();
        }

        public Task await Start_Timer()
        {
            System.Diagnostics.Debug.WriteLine("task start_timer called!");
        }
    }
}