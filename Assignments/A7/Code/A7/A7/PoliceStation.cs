using System;
using System.Collections.Generic;

namespace A7
{
    public class PoliceStation
    {
        public ICitizen[] BlackList { get; set; }
        public PoliceStation(ICitizen[] black)
        {
            this.BlackList = black;
        }
        public bool BackgroundCheck(ICitizen citizen)
        {
            foreach(ICitizen c in BlackList)
            {
                if (c == citizen)
                    return true;
            }
            return false;
        }
    }
}