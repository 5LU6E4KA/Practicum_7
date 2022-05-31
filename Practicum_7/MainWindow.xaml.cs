
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

namespace Practicum_7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Result_calculate_TextChanged(object sender, TextChangedEventArgs e){}
        private void One_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '1';
        private void Two_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '2';
        private void Three_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '3';
        private void Four_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '4';
        private void Five_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '5';
        private void Six_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '6';
        private void Seven_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '7';
        private void Eight_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '8';
        private void Nine_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '9';
        private void Null_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '0';
        private void AC_button(object sender, RoutedEventArgs e) => Result_calculate.Clear();
        private void Percent_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '%';
        private void Division_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '÷';
        private void Multiplication_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '×';
        private void Subtraction_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '-';
        private void Addition_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '+';
        private void Factorial_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '!';
        private void Dot_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '.';
        private void SquareRoot_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '√';
        private void LeftBracket_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '(';
        private void RightBracket_button(object sender, RoutedEventArgs e) => Result_calculate.Text += ')';
        private void Degree_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '^';
        private void Equals_button(object sender, RoutedEventArgs e) => Result_calculate.Text += '=';
        private void Pi_button(object sender, RoutedEventArgs e) => Result_calculate.Text += 'π';
        private void DeleteElem_button(object sender, RoutedEventArgs e)
        {
            if (Result_calculate.Text.Length != 0)
            {
                Result_calculate.Text = Result_calculate.Text.Remove(Result_calculate.Text.Length - 1);
            }
        }
        private void Start_Addiion_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

