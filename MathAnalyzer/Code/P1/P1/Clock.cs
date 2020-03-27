using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace P1
{
    public class Clock
    {
        public int CenterX;
        public int CenterY;
        public int radios;
        public Second SecondLine;
        public Minute MinuteLine;
        public Hour HourLine;
        public List<Line> Dots;
        public DateTime DateTime;
        public Clock(int x = 0, int y = 0)
        {
            this.CenterX = x;
            this.CenterY = y;
            this.SecondLine = new Second();
            this.MinuteLine = new Minute();
            this.HourLine = new Hour();
            this.Dots = new List<Line>();
            this.radios = 0;
            this.DateTime = new DateTime();
        }
        public void UpdateClock()
        {
            SecondLine.TopX = CenterX;
            MinuteLine.TopX = CenterX;
            HourLine.TopX = CenterX;
            SecondLine.TopY = CenterY;
            MinuteLine.TopY = CenterY;
            HourLine.TopY = CenterY;
            SecondLine.radios = this.radios;
            MinuteLine.radios = this.radios;
            HourLine.radios = this.radios;
            SecondLine.Update();
            MinuteLine.Update();
            HourLine.Update();
            UpdateDots();
        }

        private void UpdateDots()
        {
            List<Line> list = new List<Line>();
            for (int i = 0; i <= 59; i++)
            {
                Line dot = new Line();
                Thickness thickness = new Thickness(101, -11, 362, 250);
                dot.Margin = thickness;
                dot.Visibility = System.Windows.Visibility.Visible;
                dot.StrokeThickness = 1;
                dot.Stroke = System.Windows.Media.Brushes.Black;
                double angle = Math.PI / 30.0;
                angle = angle * i;
                dot.X1 = 1.1 * radios * Math.Sin(angle) + this.CenterX;
                dot.Y1 = -1.1 * radios * Math.Cos(angle) + this.CenterY;
                if (i % 5 == 0)
                {
                    dot.X2 = dot.X1 + (2 * dot.X1 - 2 * this.CenterX) / radios;
                    dot.Y2 = dot.Y1 + (2 * dot.Y1 - 2 * this.CenterY) / radios;
                    dot.StrokeThickness = 2;
                }
                else
                {
                    dot.X2 = dot.X1 + 1;
                    dot.Y2 = dot.Y1 + 1;
                }
                list.Add(dot);
            }
            this.Dots = list;
        }
    }
}
