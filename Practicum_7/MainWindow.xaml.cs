
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
        public MainWindow()
        {
            InitializeComponent();
            foreach(UIElement elem in MainBlock.Children)
            {
                if(elem is Button)
                {
                   ((Button)elem).Click += Button_Click;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string vvod_str = Convert.ToString(((Button)e.OriginalSource).Content);
            if (vvod_str == "AC") 
            { 
                Result.Clear(); 
            }
            else if (vvod_str == "🢠" && Result.Text.Length != 0)
            {
                Result.Text = Result.Text.Remove(Result.Text.Length - 1);
            }
            
            else if(vvod_str == "=") 
            {
                string value = new DataTable().Compute(Result.Text, null).ToString(); Result.Text = value;
            }
            else if (vvod_str == "%") 
            {
                Result.Text += "/100 ";
            }
            else 
            { 
                Result.Text += vvod_str; 
            }
        }
    }
}

