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

            HandleReceivedMessages();
		}

        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessage>(this, "TickedMessage", message =>
           {
               Device.BeginInvokeOnMainThread(() =>
               {
                   ticker.Text = message.Message;
               });
           });

            MessagingCenter.Subscribe<CancelledMessage>(this, "CancelledMessage", message =>
           {
               Device.BeginInvokeOnMainThread(() =>
               {
                   ticker.Text = "Timer Stopped";
               });
           });
        }
    }
}