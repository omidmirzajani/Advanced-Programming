using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E2
{

    public static class Threading
    {
        public static void MakeItFaster(params Action[] actions)
        {
            List<Task> tsks = new List<Task>();
            foreach (var act in actions)
            {
                tsks.Add(Task.Run(act));
            }
            Task.WhenAll(tsks).Wait();
        }
    }
}