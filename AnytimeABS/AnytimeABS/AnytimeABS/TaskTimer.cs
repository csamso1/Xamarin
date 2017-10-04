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
        public int time_interval;

        public TaskTimer(int minutes)
        {
            time_interval = minutes;
        }

        public int get_time_interval()
        {
            return time_interval;
        }

        public async Task RunTimer(CancellationToken token)
        {
            await Task.Run(async () =>
           {
               long time_in_minutes = time_interval * 60 * 1000;
               for (long i = 0; i < time_in_minutes; i++)
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
                };
           }, token);
        }
    }
}