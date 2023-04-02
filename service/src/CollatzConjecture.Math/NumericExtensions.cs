using System.Text.RegularExpressions;

namespace CollatzConjecture.Math
{
    public static class NumericExtensions
    {
        public static bool IsNumeric(this string line)
        {
            return Regex.IsMatch(line, @"^\d+$");
        }

        private static HashSet<string> EvenNumbers = new HashSet<string>()
        {
            "2",
            "4",
            "6",
            "8",
            "0"
        };
        public static bool IsEven(this string number)
        {
            return EvenNumbers.Contains(number.Last().ToString());
        }

        public static string AddZeros(this string number, int numberLength)
        {
            while (number.Length < numberLength)
                number = number.Insert(0, "0");
            return number;
        }
        public static string AddZerosIfExists(this string number, string prevLine)
        {
            bool isPrevZero = true;
            for (int i = 0; i < prevLine.Length; i++)
            {
                if (prevLine[i] == '0')
                {
                    isPrevZero = true;
                    number = number.Insert(0, "0");
                }
                else
                    break;
            }
            return number;
        }
    }
}
