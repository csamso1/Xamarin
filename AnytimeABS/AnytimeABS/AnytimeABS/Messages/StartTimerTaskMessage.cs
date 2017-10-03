using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnytimeABS.Messages
{
    public class StartTimerTaskMessage
    {
        public int num_minutes;

        public StartTimerTaskMessage(int minutes)
        {
            num_minutes = minutes;
        }

        public int getTimerInterval()
        {
            return num_minutes;
        }
    }
}
