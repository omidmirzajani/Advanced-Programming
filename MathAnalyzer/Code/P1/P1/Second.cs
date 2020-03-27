using System;
using System.Windows;
using System.Windows.Shapes;

namespace P1
{
    public class Second
    {
        public int TopX;
        public int TopY;
        public double EndX;
        public double EndY;
        public int radios;
        public Second(int x = 0, int y = 0)
        {
            this.EndX = x;
            this.EndY = y;
        }
        public void Update()
        {
            double angle = Math.PI / 30.0;
            angle = angle * DateTime.Now.Second;
            this.EndX = radios * Math.Sin(angle) + TopX;
            this.EndY = -radios * Math.Cos(angle) + TopY;
        }
        public Line Draw(Clock myclock)
        {
            Line ss = new Line();
            Thickness thickness = new Thickness(101, -11, 362, 250);
            ss.Margin = thickness;
            ss.Visibility = System.Windows.Visibility.Visible;
            ss.StrokeThickness = 2;
            ss.Stroke = System.Windows.Media.Brushes.Red;
            ss.X1 = myclock.SecondLine.TopX;
            ss.X2 = myclock.SecondLine.EndX;
            ss.Y1 = myclock.SecondLine.TopY;
            ss.Y2 = myclock.SecondLine.EndY;
            return ss;
        }
    }
}
