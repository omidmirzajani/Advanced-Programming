using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System;


namespace EventDelegateThread
{
    public static class ActionTools
    {
        private static object syncronize = new object();
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch watch = Stopwatch.StartNew();
            actions.ToList().ForEach(d => d());
            return watch.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch watch = Stopwatch.StartNew();
            List<Task> tsks = new List<Task>();
            actions.ToList().ForEach(d => tsks.Add(Task.Run(d)));
            Task.WaitAll(tsks.ToArray());
            return watch.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int len, params Action[] actions)
        {
            lock (syncronize)
            {
                Stopwatch watch = Stopwatch.StartNew();

                for (int i = 0; i < len; i++)
                {
                    foreach(var tmp in actions)
                    {
                        Task task = Task.Run(() => tmp());
                        task.Wait();
                    }
                }
            return watch.ElapsedMilliseconds;
            }

        }

        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            return await Task.Run(() => CallSequential(actions));
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            return await Task.Run(() => CallParallel(actions));
        }

        public static async Task<long> CallParallelThreadSafeAsync(int len, params Action[] actions)
        {
            return await Task.Run(() => CallParallelThreadSafe(len, actions));
        }
    }
}