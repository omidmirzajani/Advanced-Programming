using System;

namespace EventDelegateThread
{
    public interface ISingleReminder
    {
        string Msg { get; }
        int Delay { get; }
        void Start();
        event Action<string> Reminder;
    }
}