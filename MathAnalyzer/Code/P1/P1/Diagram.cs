using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace P1
{
    public class Diagram
    {
        public double v1;
        public double v2;
        public double v3;
        public double v4;
        public Canvas DiagramCanvas;
        public double oX;
        public double oY;
        public double lengX;
        public double lengY;
        public string fx;
        public Diagram(double MinX = 0, double MaxX = 0, double MinY = 0, double MaxY = 0, double ox = 0, double oy = 0)
        {
            this.v1 = MinX;
            this.v2 = MaxX;
            this.v3 = MinY;
            this.v4 = MaxY;
            this.DiagramCanvas = new Canvas();
            this.oX = ox;
            this.oY = oy;
            this.lengX = 0;
            this.lengY = 0;
            this.fx = "";
        }
        public void DrawMokhtasat()
        {
            #region X Axis
            Line x = new Line();
            x.Stroke = System.Windows.Media.Brushes.Black;
            x.StrokeThickness = 2;
            x.X1 = 0;
            x.Y1 = oY;
            x.X2 = DiagramCanvas.Width;
            x.Y2 = oY;
            DiagramCanvas.Children.Add(x);
            #endregion
            #region Y Axis
            Line y = new Line();
            y.Stroke = System.Windows.Media.Brushes.Black;
            y.StrokeThickness = 2;
            y.X1 = oX;
            y.Y1 = 0;
            y.X2 = oX;
            y.Y2 = DiagramCanvas.Height;
            DiagramCanvas.Children.Add(y);
            #endregion
            for (int i = 0; i <= (v2 - v1) * 2; i++)
            {
                Line line = new Line();
                if (i % 2 == 0)
                {
                    Label num = new Label();
                    Thickness thickness = new Thickness();
                    thickness.Top = oY - 7;
                    thickness.Left = i * lengX - 10;
                    num.Margin = thickness;
                    if((i / 2 - oX / (2 * lengX)) == Convert.ToInt32(i / 2 - oX / (2 * lengX)))
                        num.Content = Convert.ToInt32(i / 2 - oX / (2 * lengX)).ToString();
                    else
                    {
                        num.Content = Convert.ToInt32(i/2 - oX / (2 * lengX)+0.5).ToString();
                        thickness.Left += 1*lengX;
                        num.Margin = thickness;
                    }
                    DiagramCanvas.Children.Add(num);
                }
                line.Stroke = System.Windows.Media.Brushes.Gray;
                line.StrokeThickness = 1;
                line.X1 = i * lengX;
                line.X2 = line.X1;
                line.Y1 = 0;
                line.Y2 = DiagramCanvas.Height;
                DiagramCanvas.Children.Add(line);
            }
            for (int i = 1; i < (v4 - v3) * 2; i++)
            {
                Line line = new Line();
                if (i % 2 == 0 && (i / 2 - (v4 - v3) / 2) != 0)
                {
                    Label num = new Label();
                    Thickness thickness = new Thickness();
                    thickness.Top = i * lengY - 12;
                    thickness.Left = oX - 12;
                    num.Margin = thickness;
                    if((i / 2 - oY / (2 * lengY)) == Convert.ToInt32(i / 2 - oY / (2 * lengY)))
                        num.Content = Convert.ToInt32(-i / 2 + oY / (2 * lengY)).ToString();
                    else
                    {
                        num.Content = Convert.ToInt32(-i/2 + oY / (2 * lengY)-0.5).ToString();
                        thickness.Top += 1*lengY;
                        num.Margin = thickness;
                    }
                    
                    DiagramCanvas.Children.Add(num);
                }
                line.Stroke = System.Windows.Media.Brushes.Gray;
                line.StrokeThickness = 1;
                line.Y1 = i * lengY;
                line.Y2 = line.Y1;
                line.X1 = 0;
                line.X2 = DiagramCanvas.Width;
                DiagramCanvas.Children.Add(line);
            }
        }
        public void DrawDiagram(List<string> listOf)
        {
            Polyline pol = new Polyline();
            pol.Stroke = System.Windows.Media.Brushes.Red;
            for (double x = v1; x <= v2; x = x + 0.001)
            {
                double y = this.ResultOfFunction(x, listOf);
                if (oX + x * lengX * 2 > 0 && oX + x * lengX * 2 < DiagramCanvas.Width && oY - y * lengY * 2 > 0 && oY - y * lengY * 2 < DiagramCanvas.Height)
                    pol.Points.Add(new Point(oX + x * lengX * 2, oY - y * lengY * 2));
            }
            DiagramCanvas.Children.Add(pol);
        }
        public List<string> ConvertToListOfElements()
        {
            string text = fx + "+";
            List<string> result = new List<string>();
            string sub = "";
            for (int i = 0; i < text.Length; i++)
            {
                sub += text[i];
                if (text[i] == '+')
                {
                    result.Add(sub.Substring(0, sub.Length - 1));
                    sub = "";
                }
                if (text[i] == '-')
                {
                    result.Add(sub.Substring(0, sub.Length - 1));
                    sub = "-";
                }
            }
            return result;
        }
        public string Integral()
        {
            List<string> listOf = this.ConvertToListOfElements();
            string res = "";
            int indPow = 0;
            int pow = 0;
            double coefficient = 0;
            foreach (var element in listOf)
            {
                string el = element;
                if (!el.Contains("^") && !el.Contains("x"))
                    el += "x^0";
                if (!el.Contains("^") && el.Contains("x"))
                    el += "^1";
                if (el.IndexOf('x') == 0)
                    el = "1" + el;
                indPow = el.IndexOf('^');
                pow = int.Parse(el.Substring(indPow + 1));
                coefficient = Convert.ToDouble(el.Substring(0, indPow - 1));
                res += (coefficient / (pow + 1)).ToString() + "x^" + (pow + 1).ToString() + "+";
            }
            return res.Substring(0, res.Length - 1);
        }
        public string Moshtagh()
        {
            List<string> listOf = this.ConvertToListOfElements();
            string res = "";
            int indPow = 0;
            int pow = 0;
            double coefficient = 0;
            foreach (var element in listOf)
            {
                string el = element;
                if (!el.Contains("^") && !el.Contains("x"))
                    el += "x^0";
                if (!el.Contains("^") && el.Contains("x"))
                    el += "^1";
                if (el.IndexOf('x') == 0)
                    el = "1" + el;
                indPow = el.IndexOf('^');
                pow = int.Parse(el.Substring(indPow + 1));
                coefficient = Convert.ToDouble(el.Substring(0, indPow - 1));
                res += (coefficient * pow).ToString() + "x^" + (pow - 1).ToString() + "+";
            }
            return res.Substring(0, res.Length - 1);
        }
        public string MoshtaghN(int n)
        {
            string tmp = fx;
            for(int i = 1; i <=n;i++)
            {
                this.fx = Moshtagh();
            }
            string res = this.fx;
            this.fx = tmp;
            return res;
        }
        public double ResultOfFunction(double x, List<string> listOf)
        {
            double res = 0;
            int indPow = 0;
            int pow = 0;
            double coefficient = 0;
            foreach (var element in listOf)
            {
                string el = element;
                if (!el.Contains("^") && !el.Contains("x"))
                    el += "x^0";
                if (!el.Contains("^") && el.Contains("x"))
                    el += "^1";
                if (el.IndexOf('x') == 0)
                    el = "1" + el;
                indPow = el.IndexOf('^');
                pow = int.Parse(el.Substring(indPow + 1));
                if (el.Contains("n"))
                {
                    if (el.IndexOf('s') == 0)
                        el = "1" + el;
                    coefficient = Convert.ToDouble(el.Substring(0, indPow - 3));
                    res += coefficient * Math.Pow(Math.Sin(x), pow);
                }
                else if (el.Contains("c"))
                {
                    if (el.IndexOf('c') == 0)
                        el = "1" + el;
                    coefficient = Convert.ToDouble(el.Substring(0, indPow - 3));
                    res += coefficient * Math.Pow(Math.Cos(x), pow);
                }
                else if (el.Contains("g"))
                {
                    if (el.IndexOf('g') == 2)
                        el = "1" + el;
                    coefficient = Convert.ToDouble(el.Substring(0, indPow - 3));
                    res += coefficient * Math.Pow(Math.Log(x), pow);
                }
                else
                {
                    coefficient = Convert.ToDouble(el.Substring(0, indPow - 1));
                    res += coefficient * Math.Pow(x, pow);
                }

            }
            return res;
        }
        
    }
}
