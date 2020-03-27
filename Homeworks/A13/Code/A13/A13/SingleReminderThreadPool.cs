using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        private string msg;
        private int delay;
        public event Action<string> Reminder;
        public SingleReminderThreadPool(string msg, int delay)
        {
            this.msg = msg;
            this.delay = delay;
        }
        public string Msg
        {
            get
            {
                return msg;
            }
        }
        public int Delay
        {
            get
            {
                return delay;
            }
        }
        public void RaiseEvent(object information)
        {
            Reminder(msg);
        }
        public void Start()
        {
            ThreadPool.QueueUserWorkItem(RaiseEvent);
        }
    }
}