using System;
using System.Windows;
using System.Windows.Shapes;

namespace P1
{
    public class Minute
    {
        public int TopX;
        public int TopY;
        public int EndX;
        public int EndY;
        public int radios;
        public Minute(int x = 0, int y = 0)
        {
            this.EndX = x;
            this.EndY = y;
        }
        public void Update()
        {
            double angle = Math.PI / 30.0;
            angle = angle * DateTime.Now.Minute;
            this.EndX = Convert.ToInt32(radios * Math.Sin(angle)) + TopX;
            this.EndY = -Convert.ToInt32(radios * Math.Cos(angle)) + TopY;
        }
        public Line Draw(Clock myclock)
        {
            Line mm = new Line();
            Thickness thickness = new Thickness(101, -11, 362, 250);
            mm.Margin = thickness;
            mm.Visibility = System.Windows.Visibility.Visible;
            mm.StrokeThickness = 4;
            mm.Stroke = System.Windows.Media.Brushes.Black;
            mm.X1 = myclock.MinuteLine.TopX;
            mm.X2 = myclock.MinuteLine.EndX;
            mm.Y1 = myclock.MinuteLine.TopY;
            mm.Y2 = myclock.MinuteLine.EndY;
            return mm;
        }
    }
}
