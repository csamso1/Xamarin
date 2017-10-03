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
    class StartTimerTaskService : Service
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
                   var timer = new TaskCounter()
               }

           });
        }
    }
}