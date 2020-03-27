using System;
using System.Windows;
using System.Windows.Shapes;

namespace P1
{
    public class Hour
    {
        public int TopX;
        public int TopY;
        public int EndX;
        public int EndY;
        public int radios;
        public Hour(int x = 0, int y = 0)
        {
            this.EndX = x;
            this.EndY = y;
        }
        public void Update()
        {
            double angle = Math.PI / 6.0;
            double hour = DateTime.Now.Hour + DateTime.Now.Minute / 60.0;
            angle = angle * hour;
            this.EndX = Convert.ToInt32(radios * 0.5 * Math.Sin(angle)) + TopX;
            this.EndY = -Convert.ToInt32(0.5 * radios * Math.Cos(angle)) + TopY;
        }
        public Line Draw(Clock myclock)
        {
            Line hh = new Line();
            Thickness thickness = new Thickness(101, -11, 362, 250);
            hh.Margin = thickness;
            hh.Visibility = System.Windows.Visibility.Visible;
            hh.StrokeThickness = 4;
            hh.Stroke = System.Windows.Media.Brushes.Black;
            hh.X1 = myclock.HourLine.TopX;
            hh.X2 = myclock.HourLine.EndX;
            hh.Y1 = myclock.HourLine.TopY;
            hh.Y2 = myclock.HourLine.EndY;
            return hh;
        }
    }
}
