using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P1
{

    public partial class MainWindow : Window
    {
        private void Create()
        {
            var dis = new System.Windows.Threading.DispatcherTimer();
            dis.Tick += new EventHandler(OnTimer);
            dis.Interval = new TimeSpan(0, 0, 1);
            dis.Start();
        }
        private void OnTimer(object sender, EventArgs e)
        {
            Clock myclock = new Clock();
            myclock.CenterX = 0;
            myclock.CenterY = 75;
            myclock.radios = 50;

            Second s = new Second();
            Minute m = new Minute();
            Hour h = new Hour();

            myclock.SecondLine = s;
            myclock.MinuteLine = m;
            myclock.HourLine = h;

            Line second = myclock.SecondLine.Draw(myclock);
            Line minute = myclock.MinuteLine.Draw(myclock);
            Line hour = myclock.HourLine.Draw(myclock);

            Total.Children.Clear();
            myclock.UpdateClock();

            second = myclock.SecondLine.Draw(myclock);
            minute = myclock.MinuteLine.Draw(myclock);
            hour = myclock.HourLine.Draw(myclock);

            Total.Children.Add(second);
            Total.Children.Add(minute);
            Total.Children.Add(hour);
            int counter = 0;
            Thickness o = new Thickness();

            foreach (var t in myclock.Dots)
            {
                //if(counter%5==0)
                //{
                //    o.Top = t.X1;
                //    o.Left = t.Y1;
                //    Label label = new Label();

                //    label.Content = Convert.ToString(counter / 5 + 1);
                //    label.Margin = o;
                //    Total.Children.Add(label);
                //}
                //else
                Total.Children.Add(t);
                counter++;
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            Create();
            #region Commented

            #endregion
        }

        private void TabItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
            func.fx = fx.Text;
            func.oX = DiagramCanvas.Width / 2 + double.Parse(ox.Text);
            func.oY = DiagramCanvas.Height / 2 + double.Parse(oy.Text);
            func.lengX = DiagramCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = DiagramCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = DiagramCanvas;
            func.DrawMokhtasat();
            List<string> listOf = func.ConvertToListOfElements();
            func.DrawDiagram(listOf);
        }       
        public List<string> ConvertToListOfElements(string text)
        {
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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DiagramCanvas.Children.Clear();
            Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
            func.oX = DiagramCanvas.Width / 2+double.Parse(ox.Text);
            func.oY = DiagramCanvas.Height / 2+double.Parse(oy.Text);
            func.lengX = DiagramCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = DiagramCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = DiagramCanvas;
            func.DrawMokhtasat();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DiagramCanvas_Scroll(object sender, MouseWheelEventArgs e)
        {
            double x = e.Delta / Math.Abs(e.Delta);
            if (double.Parse(MinX.Text) + x < double.Parse(MaxX.Text) - x && double.Parse(MinY.Text) + x < double.Parse(MaxY.Text) - x)
            {
                MinX.Text = (double.Parse(MinX.Text) + x).ToString();
                MaxX.Text = (double.Parse(MaxX.Text) - x).ToString();
                MinY.Text = (double.Parse(MinY.Text) + x).ToString();
                MaxY.Text = (double.Parse(MaxY.Text) - x).ToString();
            }
            DiagramCanvas.Children.Clear();
            Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
            func.oX = DiagramCanvas.Width / 2+double.Parse(ox.Text);
            func.oY = DiagramCanvas.Height / 2 + double.Parse(oy.Text);
            func.lengX = DiagramCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = DiagramCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = DiagramCanvas;
            func.DrawMokhtasat();
            List<string> listOf = ConvertToListOfElements(fx.Text + "+");
            func.DrawDiagram(listOf);
        }

        private void Clear_Equation_Click(object sender, RoutedEventArgs e)
        {
            EqCanvas.Children.Clear();
            EqCanvas.Visibility = System.Windows.Visibility.Hidden;
            Solutions.Visibility = System.Windows.Visibility.Visible;
            Result.Text = "";
            Solutions.Text = "";
        }
        public List<string> ConvertToVariables(string text)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                if (Convert.ToInt32(text[i]) > 96 && Convert.ToInt32(text[i]) < 123 && !result.Contains(text[i].ToString()))
                    result.Add(text[i].ToString());
            }
            result.Sort();
            return result;
        }
        public List<double[]> DeleteIJ(List<double[]> nums, int i, int j)
        {
            List<double[]> result = new List<double[]>();
            for (int column = 0; column < nums.Count; column++)
            {
                List<double> temp = new List<double>();
                for (int row = 0; row < nums[column].Length; row++)
                {
                    if (column != i && row != j)
                        temp.Add(nums[column][row]);
                }
                if (column != i)
                    result.Add(temp.ToArray());
            }
            return result;
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            List<string> variables = ConvertToVariables(Solutions.Text);
            List<string> sol = Solutions.Text.Split(',').ToList();
            List<double[]> coeficients = ConvertToCoeficients(variables, sol);
            List<double> consts = ConvertToConsts(sol);
            double det = Determinan(coeficients.ToArray());
            string NO_Solution = "";
            if (det == 0)
                NO_Solution += "0";
            string print = "";
            double x2D = 0;
            double y2D = 0;
            for (int i = 0; i < sol.Count; i++)
            {
                List<double[]> surat = ChangeColumnI(coeficients, i, consts);
                if (Determinan(surat.ToArray()) == 0)
                    NO_Solution += "0";
                double res = Determinan(surat.ToArray()) / det;
                if (i == 0)
                    x2D = res;
                if (i == 1)
                    y2D = res;
                print += variables[i] + ":" + res.ToString() + " , ";
            }
            if (NO_Solution == "")
                Result.Text = print.Substring(0, print.Length - 2);
            else if (NO_Solution.Length == sol.Count + 1)
                Result.Text = "No Unique Solution ";
            else
                Result.Text = "No Solution ";
            if (variables.Count == 2)
            {
                Solutions.Visibility = System.Windows.Visibility.Hidden;
                EqCanvas.Visibility = System.Windows.Visibility.Visible;                                
                int v1 = -3;
                int v2 = +3;
                int v3 = -3;
                int v4 = +3;
                #region First Line
                Diagram func = new Diagram(v1, v2, v3, v4);
                func.oX = EqCanvas.Width / 2;
                func.oY = EqCanvas.Height / 2;
                func.lengX = EqCanvas.Width / (2 * func.v2 - 2 * func.v1);
                func.lengY = EqCanvas.Height / (2 * func.v4 - 2 * func.v3);
                func.DiagramCanvas = EqCanvas;
                func.DrawMokhtasat();
                func.fx = (consts[0] / coeficients[0][1]).ToString();
                if (coeficients[0][0] / coeficients[0][1] < 0)
                {
                    func.fx += "+";
                    func.fx += (-coeficients[0][0] / coeficients[0][1]).ToString();                    
                }
                else
                {
                    func.fx += "-";
                    func.fx += (coeficients[0][0] / coeficients[0][1]).ToString();
                }
                func.fx += "x";
                List<string> listOf = ConvertToListOfElements(func.fx + "+");
                func.DrawDiagram(listOf);
                #endregion
                #region Second Line
                func.fx = (consts[1] / coeficients[1][1]).ToString();
                if (coeficients[1][0] / coeficients[1][1] < 0)
                {
                    func.fx += "+";
                    func.fx += (-coeficients[1][0] / coeficients[1][1]).ToString();
                }
                else
                {
                    func.fx += "-";
                    func.fx += (coeficients[1][0] / coeficients[1][1]).ToString();
                }
                func.fx += "x";
                listOf = ConvertToListOfElements(func.fx + "+");
                func.DrawDiagram(listOf);
                #endregion
                #region Barkhord
                Ellipse ellipse = new Ellipse();
                Thickness tt = new Thickness();
                tt.Top = EqCanvas.Height / 2 - y2D * func.lengY * 2 - 5;
                tt.Left = EqCanvas.Width / 2 + x2D * func.lengX * 2 - 5;
                ellipse.Stroke = System.Windows.Media.Brushes.Black;
                ellipse.Width = 10;
                ellipse.Height = 10;
                ellipse.Margin = tt;
                ellipse.Fill = System.Windows.Media.Brushes.Black;
                EqCanvas.Children.Add(ellipse);
                #endregion
            }
        }

        private List<double[]> ChangeColumnI(List<double[]> coeficients, int i, List<double> consts)
        {
            List<double[]> result = new List<double[]>();
            for (int x = 0; x < coeficients.Count; x++)
            {
                List<double> num = new List<double>();
                for (int y = 0; y < coeficients.Count; y++)
                {
                    if (y == i)
                        num.Add(consts[x]);
                    else
                        num.Add(coeficients[x][y]);

                }
                result.Add(num.ToArray());
            }
            return result;
        }

        private List<double> ConvertToConsts(List<string> sol)
        {
            List<double> result = new List<double>();
            foreach (var t in sol)
            {
                result.Add(double.Parse(t.Substring(t.IndexOf('=') + 1)));
            }
            return result;
        }

        private List<double[]> ConvertToCoeficients(List<string> variables, List<string> sol)
        {
            List<double[]> coeficients = new List<double[]>();
            foreach (var t in sol)
            {
                double[] coef = new double[sol.Count];
                for (int i = 0; i < sol.Count; i++)
                    coef[i] = 0;
                int ind = t.IndexOf('=');
                List<string> elements = ConvertToListOfElements(t.Substring(0, ind) + "+");
                foreach (var element in elements)
                {
                    if (element.Length != 0)
                    {
                        int index = variables.IndexOf(element[element.Length - 1].ToString());
                        if (element.Length == 1)
                            coef[index] = 1;
                        else if (element.Length == 2 && element[0] == '-')
                            coef[index] = -1;
                        else
                            coef[index] = double.Parse(element.Substring(0, element.Length - 1));
                    }
                }
                coeficients.Add(coef);
            }
            return coeficients;
        }

        private double Determinan(double[][] v)
        {
            if (v.Length == 2)
                return v[0][0] * v[1][1] - v[0][1] * v[1][0];
            double det = 0;
            for (int i = 0; i < v.Length; i++)
            {
                double[][] del = DeleteIJ(v.ToList(), i, 0).ToArray();
                det += v[i][0] * Determinan(del) * Math.Pow(-1, i);
            }
            return det;
        }

        private void Taylor_Draw(object sender, RoutedEventArgs e)
        {
            int xlimit = Convert.ToInt32((XLimit(int.Parse(nNum.Text))) + 1) * 2;
            Diagram func = new Diagram(-xlimit, +xlimit, -3, 3);
            func.oX = TaylorCanvas.Width / 2;
            func.oY = TaylorCanvas.Height / 2;
            func.lengX = TaylorCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = TaylorCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = TaylorCanvas;
            func.DrawMokhtasat();
            Polyline polSinx = new Polyline();
            Polyline pol = new Polyline();
            pol.Stroke = System.Windows.Media.Brushes.Black;
            polSinx.Stroke = System.Windows.Media.Brushes.Red;
            //string s=(XLimit(int.Parse(nNum.Text)).ToString());
            for (double x = func.v1; x <= func.v2; x = x + .01)
            {
                polSinx.Points.Add(new Point(func.oX + x * func.lengX * 2, func.oY - Math.Sin(x) * func.lengY * 2));
                double pointX = func.oX + x * func.lengX * 2;
                double pointY = func.oY - Taylor(x - double.Parse(xZero.Text), int.Parse(nNum.Text)) * func.lengY * 2;
                if (pointX > 0 && pointX < TaylorCanvas.Width && pointY > 0 && pointY < TaylorCanvas.Height)
                    pol.Points.Add(new Point(func.oX + x * func.lengX * 2, func.oY - Taylor(x - double.Parse(xZero.Text), int.Parse(nNum.Text)) * func.lengY * 2));
            }
            TaylorCanvas.Children.Add(polSinx);
            TaylorCanvas.Children.Add(pol);

        }

        public double Taylor(double x, int n)
        {
            double result = 0;
            for (int i = 1; i <= n * 2 - 1; i = i + 2)
            {
                result += (2 - i % 4) * Math.Pow(x, i) / Factorial(i);
            }
            return result;
        }
        public double XLimit(int n)
        {
            double result = 0.1;
            for (double i = 0.1; i <= 100; i=i+0.1)
            {
                double t = Math.Abs(Taylor(result, n));
                if (Math.Abs(Taylor(result, n) - Math.Sin(result)) / Math.Sin(result) < 0.2)
                {
                    result = i;
                }
            }
            return result;

        }
        public double Factorial(int i)
        {
            double result = 1;
            for (int j = 1; j <= i; j++)
                result *= j;
            return result;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaylorCanvas.Children.Clear();
        }


        private void Show_Shib(object sender, RoutedEventArgs e)
        {
            Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
            func.fx = fx.Text;
            func.fx = func.Moshtagh();
            Derivedfx.Text = func.fx;
            func.oX = DiagramCanvas.Width / 2 + double.Parse(ox.Text);
            func.oY = DiagramCanvas.Height / 2 + double.Parse(oy.Text);
            func.lengX = DiagramCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = DiagramCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = DiagramCanvas;
            func.DrawMokhtasat();
            List<string> listOf = func.ConvertToListOfElements();
            MessageBox.Show("Derived Is: " + func.ResultOfFunction(double.Parse(XMoshtagh.Text), listOf).ToString());
            func.DrawDiagram(listOf);
        }

        private void Antegral_Click(object sender, RoutedEventArgs e)
        {
            Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
            func.fx = fx.Text;
            func.fx = func.Integral();
            Integralfx.Text = func.fx;
            func.oX = DiagramCanvas.Width / 2 + double.Parse(ox.Text);
            func.oY = DiagramCanvas.Height / 2 + double.Parse(oy.Text);
            func.lengX = DiagramCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = DiagramCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = DiagramCanvas;
            func.DrawMokhtasat();
            List<string> listOf = func.ConvertToListOfElements();
            MessageBox.Show("Integral Is: " + func.ResultOfFunction(double.Parse(XMoshtagh.Text), listOf).ToString());
            func.DrawDiagram(listOf);
        }

        

        private void Drag(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Point p = Mouse.GetPosition(DiagramCanvas);
                DiagramCanvas.Children.Clear();
                double DiffX = (p.X - DiagramCanvas.Width / 2);
                double DiffY = (p.Y - DiagramCanvas.Height / 2);


                Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
                func.fx = fx.Text;

                func.lengX = DiagramCanvas.Width / (2 * func.v2 - 2 * func.v1);
                func.lengY = DiagramCanvas.Height / (2 * func.v4 - 2 * func.v3);
                DiffX = Convert.ToInt32(DiffX / func.lengX) * func.lengX;
                DiffY = Convert.ToInt32(DiffY / func.lengY) * func.lengY;
                ox.Text = DiffX.ToString();
                oy.Text = DiffY.ToString();

                func.oX = DiagramCanvas.Width / 2 + double.Parse(ox.Text);
                func.oY = DiagramCanvas.Height / 2 + double.Parse(oy.Text);
                func.DiagramCanvas = DiagramCanvas;
                func.DrawMokhtasat();
                List<string> listOf = func.ConvertToListOfElements();
                func.DrawDiagram(listOf);
            }
        }
        public double TaylorD(string x,int n,double num, double x0)
        {
            double res = 0;
            Diagram func = new Diagram();
            func.fx = x;
            for(int i=0;i<n;i++)
            {
                string moshtagh = func.MoshtaghN(i);
                func.fx = moshtagh;
                List<string> listOf = func.ConvertToListOfElements();
                double moshta = func.ResultOfFunction(num-x0, listOf);
                res += moshta * Math.Pow(num-x0, i)/Factorial(i);
            }
            return res;
        }
        private void Delkhah_Click(object sender, RoutedEventArgs e)
        {
            Diagram func = new Diagram(double.Parse(MinX.Text), double.Parse(MaxX.Text), double.Parse(MinY.Text), double.Parse(MaxY.Text));
            func.fx = Delkhah.Text;
            func.oX = TaylorCanvas.Width / 2 + double.Parse(ox.Text);
            func.oY = TaylorCanvas.Height / 2 + double.Parse(oy.Text);
            func.lengX = TaylorCanvas.Width / (2 * func.v2 - 2 * func.v1);
            func.lengY = TaylorCanvas.Height / (2 * func.v4 - 2 * func.v3);
            func.DiagramCanvas = TaylorCanvas;
            func.DrawMokhtasat();

            Polyline pol = new Polyline();
            pol.Stroke = System.Windows.Media.Brushes.Red;
            for (double x = func.v1; x <= func.v2; x = x + 0.001)
            {
                double y = TaylorD(func.fx, Convert.ToInt32(nNum.Text), x,double.Parse(xZero.Text));
                if (func.oX + x * func.lengX * 2 > 0 && func.oX + x * func.lengX * 2 < DiagramCanvas.Width && func.oY - y * func.lengY * 2 > 0 && func.oY - y * func.lengY * 2 < DiagramCanvas.Height)
                    pol.Points.Add(new Point(func.oX + x * func.lengX * 2, func.oY - y * func.lengY * 2));
            }
            TaylorCanvas.Children.Add(pol);
        }

        private void Delkhah_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(DiagramCanvas, "My First Print Job");
            }
        }

        
    }
}
