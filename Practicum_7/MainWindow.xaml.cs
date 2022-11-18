using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data;

namespace Practicum_7
{
    public partial class MainWindow : Window
    {
        public delegate void Error(string text);
        public event Error? Notify;

        public void ShowError(string text)
        {
            MessageBox.Show(text, "Exceptions", MessageBoxButton.OK, MessageBoxImage.Error);
            Result.Clear();
        }
        public MainWindow()
        {
            Notify += ShowError;
            InitializeComponent();
            foreach (UIElement elem in MainBlock.Children)
            {
                if (elem is Button)
                {
                    Button btn = ((Button)elem);
                    btn.Click += Button_Click;
                    btn.Background = (btn.Content.ToString() == "=") ? new SolidColorBrush(Colors.Blue) : (btn.Content.ToString() == "AC") ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.White);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string vvod_str = Convert.ToString(((Button)e.OriginalSource).Content);

                switch (vvod_str)
                {
                    case "AC":
                        Result.Clear();
                        break;

                    case "🢠":
                        Result.Text = Result.Text.Length != 0 ? Result.Text.Remove(Result.Text.Length - 1) : null;
                        break;

                    case "π":
                        Result.Text += " * 3.141592653589793";
                        break;

                    case "=":
                        try
                        {
                            
                            Result.Text = InputFactorialString(Result.Text);
                            string value = new DataTable().Compute(Sqrt_str(Result.Text + " ").Replace("%", "/100"), null) ? .ToString();
                            Result.Text = value;
                        }
                        catch
                        {
                            throw new Exception("Действие выполнить невозможно");
                        }
                        break;
                    default:
                        Result.Text += vvod_str;
                        break;
                }
            }
            catch (Exception ex)
            {
                Notify?.Invoke(ex.Message);
            }
        }
        public static double Factorial(int num)
        {
            if (num == 1) return 1;
            if (num >= 0)
            {
                double result = num * Factorial(num - 1);
                return result;
            }
            return 0;
        }
        public static string InputFactorialString(string letter)
        {
            try
            {
                while (letter.Contains('!'))
                {
                    int i = letter.IndexOf('!') - 1;
                    string exp = "";
                    string res = "";

                    int count_f = 0;
                    int count_l = 1;
                    while (count_f != count_l)
                    {
                        i--;
                        if (letter[i] == ')')
                        {
                            count_l++;
                        }
                        if (letter[i] == '(')
                        {
                            count_f++;
                        }
                        exp = exp.Insert(0, letter[i].ToString());
                    }
                    exp += ")";
                   
                    res = new DataTable().Compute(exp, String.Empty).ToString().Replace(',', '.');
                    try
                    {
                        int fact = Convert.ToInt32(res);
                        letter = letter.Remove(i, letter.IndexOf('!') - i + 1);
                        letter = letter.Insert(i, Factorial(fact).ToString().Replace(',', '.'));
                    }
                    catch
                    {
                        return "Ошибка вычисления факториала!";
                    }             
                }
                return letter;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Sqrt_str(string expression)
        {
            try
            {

                while (expression.Contains('√'))
                {
                    int i = expression.IndexOf('√') + 1;
                    int j;
                    int index = expression.IndexOf('√');
                    string exp = "";

                    while (Enumerable.Range(0, 10).Select(x => x.ToString()).Contains(expression[i].ToString()))
                    {
                        i++;
                    }
                    i--;
                    j = i;
                    while (i > expression.IndexOf('√'))
                    {
                        exp = exp.Insert(0, expression[i].ToString());
                        i--;
                    }
                    double sqr = Convert.ToDouble(exp);
                    expression = expression.Remove(index, j - index + 1);
                    expression = expression.Insert(index, Math.Sqrt(sqr).ToString().Replace(',', '.'));
                }
            }
            catch
            {
                return "Error";
            }
            return expression;
        }
       
    }
}

