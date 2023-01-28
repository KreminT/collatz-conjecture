using System.Text.RegularExpressions;

namespace CollatzConjecture.Math
{
    public static class NumericExtensions
    {
        public static bool IsNumeric(this string line)
        {
            return Regex.IsMatch(line, @"^\d+$");
        }

        public static List<string> SplitNumericToParts(this string line, int numbersInPart)
        {
            List<string> parts = new List<string>();
            if (string.IsNullOrEmpty(line))
                return parts;
            int nextIndex = 0;
            while (true)
            {
                if (nextIndex == line.Length)
                    break;
                if (nextIndex + numbersInPart > line.Length)
                    parts.Add(line.Substring(nextIndex, line.Length - nextIndex));
                else
                    parts.Add(line.Substring(nextIndex, numbersInPart));
                nextIndex += numbersInPart;
                if (nextIndex > line.Length)
                    break;
            }
            return parts;
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

        public static string AddZeros(this string number,int numberLength)
        {
            while (number.Length < numberLength)
                number = number.Insert(0, "0");
            return number;
        }
    }
}
