using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AnytimeABS.Messages;
using Xamarin.Forms;

namespace AnytimeABS
{
    class TaskTimer
    {
        public async Task StartTimer(CancellationToken token)
        {
            await Task.Run(async () =>
           {
               for (long i = 0; i < long.MaxValue; i++)
               {
                   token.ThrowIfCancellationRequested();
                   await Task.Delay(500);
                   var message = new TickedMessage
                   {
                       Message = i.ToString()
                   };

                   Device.BeginInvokeOnMainThread(() =>
                   {
                       MessagingCenter.Send<TickedMessage>(message, "TickedMessage");
                   });
               }
           }, token);
        }
    }
}
