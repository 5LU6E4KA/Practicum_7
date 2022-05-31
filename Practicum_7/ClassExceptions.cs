using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum_7
{
    internal class ExceptFunctions
    {
        public static Exception Double_error(string input_string, string text, double min = -1.7976931348623157E+308, double max = 1.7976931348623157E+308)
        {
            try
            {
                double result = double.Parse(input_string);
                if (result < min)
                {
                    throw new Exception($"Число меньше разрешенного");
                }
                if (result > max)
                {
                    throw new Exception($"Число больше разрешенного");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
        public static Exception Int_error(string input_string, string text, int min = -2147483648, int max = 2147483647)
        {
            try
            {
                int result = Convert.ToInt32(input_string);
                if (result < min)
                {
                    throw new Exception($"Число меньше разрешенного");
                }
                if (result > max)
                {
                    throw new Exception($"Число больше разрешенного");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }
}   
