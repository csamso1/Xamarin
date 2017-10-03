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
    public class TaskTimer
    {
        public async Task RunTimer(CancellationToken token)
        {
            await Task.Run(async () =>
           {
               for (long i = 0; i < long.MaxValue; i++)
               {
                   token.ThrowIfCancellationRequested();
                   await Task.Delay(1000);
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