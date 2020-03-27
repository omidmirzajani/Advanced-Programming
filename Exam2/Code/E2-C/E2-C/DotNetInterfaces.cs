using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max = 100)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            yield return 0;
            for (int i = 0; i < max; i++)
            {
                timer.Stop();
                long TimeElapsed = timer.ElapsedMilliseconds;
                timer = new Stopwatch();
                timer.Start();
                yield return TimeElapsed;
            }
            timer.Stop();
        }
    }
}