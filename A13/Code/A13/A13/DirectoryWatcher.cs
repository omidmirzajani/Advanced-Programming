using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegateThread
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher watch;
        private Action<string> Msg = null;

        public DirectoryWatcher(string dir)
        {
            watch = new FileSystemWatcher(dir);
            watch.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
            watch.EnableRaisingEvents = true;
        }

        private void OnCreated(object mob, FileSystemEventArgs fse)
        {
            Msg?.Invoke(fse.FullPath);
        }

        private void OnDeleted(object mob, FileSystemEventArgs fse)
        {
            Msg?.Invoke(fse.FullPath);
        }

        public void Register(Action<string> MsgTo, ObserverType observerType)
        {
            if(observerType == ObserverType.Create)
                watch.Created += new FileSystemEventHandler(OnCreated);
            else
                watch.Deleted += new FileSystemEventHandler(OnDeleted);

            this.Msg += MsgTo;
        }

        public void Unregister(Action<string> notifyMe, ObserverType observerType)
        {
            if (observerType == ObserverType.Create)
                watch.Created -= new FileSystemEventHandler(OnCreated);
            else
                watch.Deleted -= new FileSystemEventHandler(OnDeleted);

            this.Msg -= notifyMe;
        }
        public void Dispose()
        {
            watch = null;
        }
    }
}