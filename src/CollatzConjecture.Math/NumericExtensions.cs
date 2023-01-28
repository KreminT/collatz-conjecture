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
    }
}
