using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegateThread
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReminderTask = null;
        private int delay;
        private string msg;
        public event Action<string> Reminder;
        public SingleReminderTask(string msg, int delay)
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
            ReminderTask = new Task(() => Reminder(msg));
            ReminderTask.Start();
        }
    }
}