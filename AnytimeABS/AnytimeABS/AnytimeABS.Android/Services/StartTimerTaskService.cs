using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using AnytimeABS.Messages;

namespace AnytimeABS.Droid.Services
{
    [Service]
    public class StartTimerTaskService : Service
    {
        CancellationTokenSource _cts;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            _cts = new CancellationTokenSource();

            Task.Run(() =>
           {
               try
               {
                   //Invoke the shared code
                   
                   var timer = new TaskTimer(1);
                   //need to pass time in minutes instead of 1 in line below, testing 1 minute
                   timer.RunTimer(_cts.Token).Wait();
               }
               catch (System.OperationCanceledException) { }
               finally
               {
                   if(_cts.IsCancellationRequested)
                   {
                       var message = new CancelledMessage();
                       Device.BeginInvokeOnMainThread(
                           () => MessagingCenter.Send(message, "CancelledMessage")
                       );
                   }
               }
           }, _cts.Token );
            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            if(_cts != null)
            {
                _cts.Token.ThrowIfCancellationRequested();

                _cts.Cancel();
            }
            base.OnDestroy();
        }
    }
}