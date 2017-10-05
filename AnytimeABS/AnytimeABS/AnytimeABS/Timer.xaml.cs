using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnytimeABS.Messages;
using System.Threading;
using AnytimeABS.Dependency;
using AnytimeABS.Services;

namespace AnytimeABS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer : ContentPage
	{
        //Declaring class variables
        bool Timer_Running = false;
        int num_minutes;
        int num_milliseconds;
        int sec_remaning;
        int min_remaning;
        int min_elapsed;
        public Timer (int index)
		{
			InitializeComponent ();
            //Avalible time intervals in minutes
            int[] time_intervals = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            if(! (index >= 0))
            {
                index = 0;
            }
            num_minutes = time_intervals[index];
            num_milliseconds = num_minutes * 60 * 1000;
            //Wiring up XAML buttons
            StartTimer.Clicked += (s, e) =>
            {
                Timer_Running = true;
                start_the_timer();
                async void start_the_timer()
                {
                    var message = new StartTimerTaskMessage(time_intervals[index]);
                    MessagingCenter.Send(message, "StartTimerTaskMessage");
                    System.Diagnostics.Debug.WriteLine("Timer Started, Delay = " + num_milliseconds);
                    await Task.Delay(num_milliseconds);
                    System.Diagnostics.Debug.WriteLine("about to call stop_timer().");
                    stop_timer();
                    if(Timer_Running == true)
                    {
                        start_the_timer();
                    }
                }
            };

            StopTimer.Clicked += (s, e) =>
            {
                var message = new StopTimerTaskMessage();
                MessagingCenter.Send(message, "StopTimerTaskMessage");
                Timer_Running = false;
            };

            void stop_timer()
            {
                
                var message = new StopTimerTaskMessage();
                MessagingCenter.Send(message, "StopTimerTaskMessage");
                //Plays the tone
                DependencyService.Get<IAudio>().PlayMp3File("ding.mp3");
                //Timer_Running = false;
            }

            HandleReceivedMessages();
		}

        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessage>(this, "TickedMessage", message =>
           {
               Device.BeginInvokeOnMainThread(() =>
               {
                   ticker.TextColor = Color.White;
                   ticker.FontSize = 50;
                   int sec_elapsed = Int32.Parse(message.Message);
                   if(sec_elapsed == 0)
                   {
                       min_elapsed = 0;
                   }
                   else
                   {
                       min_elapsed = 60 % sec_elapsed;
                   }
                   System.Diagnostics.Debug.WriteLine("sec_elapsed = " + sec_elapsed);
                   System.Diagnostics.Debug.WriteLine("min_elapsed = " + min_elapsed);
                   min_remaning = (num_minutes * 60) - (sec_elapsed * 60) / 60;
                   System.Diagnostics.Debug.WriteLine("min_remaning = " + min_remaning);
                   if (min_elapsed == 0)
                   {
                       sec_remaning = 60 - sec_elapsed;
                   }
                   else
                   {
                       sec_remaning = num_minutes % min_elapsed;
                   }
                   if (sec_elapsed != 0)
                   {
                       //min_remaning = num_minutes / sec_remaning;
                       if(min_remaning == 0)
                       {
                           sec_remaning = 60 - sec_elapsed;
                       }
                       else
                       {
                           sec_remaning = (num_minutes * 60) % sec_elapsed;
                       }
                   }
                   String formatted_sec_remaning = String.Format("{0:00}", sec_remaning);
                   ticker.Text = min_remaning + ":" + formatted_sec_remaning;
               });
           });

            MessagingCenter.Subscribe<CancelledMessage>(this, "CancelledMessage", message =>
           {
               Device.BeginInvokeOnMainThread(() =>
               {
                   ticker.TextColor = Color.White;
                   ticker.FontSize = 50;
                   ticker.Text = "Tighten Up!";
               });
           });

            MessagingCenter.Subscribe<StopTimerTaskMessage>(this, "StopTimerTaskMessage", message =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ticker.Text = "Timer Stopped";
                });
            });
        }
    }
}