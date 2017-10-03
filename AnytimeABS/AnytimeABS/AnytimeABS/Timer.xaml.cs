using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnytimeABS.Messages;
using System.Threading;

namespace AnytimeABS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer : ContentPage
	{
		public Timer (int index)
		{
			InitializeComponent ();
            //Avalible time intervals in minutes
            int[] time_intervals = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int num_minutes = time_intervals[index];
            int num_milliseconds = num_minutes * 60 * 1000;
            //Wiring up XAML buttons
            StartTimer.Clicked += (s, e) =>
            {
                start_the_timer();
                async void start_the_timer()
                {
                    while (true)
                    {
                        var message = new StartTimerTaskMessage(time_intervals[index]);
                        MessagingCenter.Send(message, "StartTimerTaskMessage");
                        System.Diagnostics.Debug.WriteLine("Timer Started, Delay = " + num_milliseconds);
                        await Task.Delay(num_milliseconds);
                        System.Diagnostics.Debug.WriteLine("about to call stop_timer().");
                        stop_timer();
                    }
                }
            };

            StopTimer.Clicked += (s, e) =>
            {
                var message = new StopTimerTaskMessage();
                MessagingCenter.Send(message, "StopTimerTaskMessage");
            };

            void stop_timer()
            {
                var message = new StopTimerTaskMessage();
                MessagingCenter.Send(message, "StopTimerTaskMessage");
                //ToDo play tone
            }

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