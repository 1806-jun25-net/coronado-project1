using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApplication.UI
{
    public static class HelperIO
    {
        public static string ReadLine()
        {
            var input = Console.ReadLine();
            input = FormatString(input);
            return input;
        }
        public static string FormatString(string input)
        {
            input = input.ToLower(); // set whole string to lower case
            input = char.ToUpper(input[0]) + input.Substring(1); // capitalize first letter and concatenate rest of string
            return input;
        }
    }
}
