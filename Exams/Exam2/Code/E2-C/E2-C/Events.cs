using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        int i = 0;
        List<int> list = new List<int>();
        public void AddNumber(int num)
        {
            if (!Check(list, num))
            {
                DuplicateNumberAdded(i++);
            }
            else
                list.Add(num);

        }

        private bool Check(List<int> list, int num)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == num)
                    return false;
            }
            return true;
        }

        public event Action<int> DuplicateNumberAdded;
    }
}