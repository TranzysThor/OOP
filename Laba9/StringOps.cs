using System;
using System.Collections.Generic;

namespace Laba9
{
    public static class StringOps
    {
        public static Func<string, string> RemoveCommas = str =>
        {
            while (str.Contains(','))
            {
                str = str.Remove(str.IndexOf(','), 1);
            }

            return str;
        };

        public static Action<string> PrintStr = str => Console.WriteLine(str);
        public static Func<string, List<string>> LicketySplit = str => new List<string>(str.Split(" "));
        public static Func<string, string> Caps = str => str.ToUpper();

        public static Func<string, string> RemoveDoubleSpaces = str =>
        {
            while (str.Contains("  "))
            {
                str = str.Remove(str.IndexOf("  "), 1);
            }

            return str;
        };
    }
}