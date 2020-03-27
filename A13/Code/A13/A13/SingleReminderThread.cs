using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReminderThread = null;
        private int delay;
        private string msg;
        public event Action<string> Reminder;
        public SingleReminderThread(string msg, int delay)
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
        public void Start()
        {
            ReminderThread = new Thread(() => Reminder(msg));
            ReminderThread.Start();
        }
    }
}