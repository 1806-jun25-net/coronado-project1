using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization; // to use Title Case method

namespace PizzaApplication.Library
{
    public static class HelperIO
    {
        public static string ReadLine() // acts as a Console.ReadLine() with a custom HelperIO.FormatString() method to format strings like so: "reTURnINg" -> "Returning"
        {
            var input = Console.ReadLine();
            input = FormatString(input);
            return input;
        }
        public static string FormatString(string input)
        {
            input = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input); // formats input string into Title Case
            
            return input;
        }
    }
}
