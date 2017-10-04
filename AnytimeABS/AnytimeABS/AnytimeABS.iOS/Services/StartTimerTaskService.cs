using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnytimeABS.Messages;
using Foundation;
using UIKit;
using Xamarin.Forms;

namespace AnytimeABS.iOS.Services
{
    class StartTimerTaskService
    {
        nint _taskId;
        CancellationTokenSource _cts;

        public async Task Start ()
        {
            _cts = new CancellationTokenSource();
            _taskId = UIApplication.SharedApplication.BeginBackgroundTask("StartTimer", OnExpiration);

            try
            {
                //Invoke the shared code
                var counter = new TaskTimer(1);
                await counter.RunTimer(_cts.Token);
            } catch(OperationCanceledException) {
            }
            finally
            {
                if (_cts.IsCancellationRequested)
                {
                    var message = new CancelledMessage();
                    Device.BeginInvokeOnMainThread(
                           () => MessagingCenter.Send(message, "CancelledMessage")
                    );
                }
            }
            UIApplication.SharedApplication.EndBackgroundTask(_taskId);
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        void OnExpiration()
        {
            _cts.Cancel();
        }
    }
}