using System;
using System.IO;


namespace EventDelegateThread
{
    public class SingleFileWatcher: IDisposable
    {
        private Action Msg;
        private FileSystemWatcher watch;
        public SingleFileWatcher(string fileName)
        {
            watch = new FileSystemWatcher(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));
            watch.Changed += OnChanged;
            watch.EnableRaisingEvents = true;
        }
        private void OnChanged(object MsgTo, FileSystemEventArgs fse)
        {
                Msg?.Invoke();
        }
        public void Register(Action msg)
        {
            this.Msg += msg;
        }
        public void Unregister(Action msg)
        {
            this.Msg -= msg;
        }
        public void Dispose()
        {
            this.watch = null;
        }
    }
}