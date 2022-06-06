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
            MessageBox.Show(text, "Exceptions", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            Result.Clear();
        }
        public MainWindow()
        {
            Notify += ShowError;
            InitializeComponent();
            foreach(UIElement elem in MainBlock.Children)
            {
                if(elem is Button)
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
                
                switch(vvod_str)
                {
                    case "AC":
                        Result.Clear();
                        break;

                    case "🢠":
                        Result.Text = Result.Text.Length != 0 ? Result.Text.Remove(Result.Text.Length - 1) : null;
                        break;

                    case "=":
                        try
                        {
                            string value = new DataTable().Compute(Sqrt_str(Result.Text + " ").Replace("%", "/100"), null).ToString(); Result.Text = value;
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

