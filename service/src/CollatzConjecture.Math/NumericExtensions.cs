using System.Text.RegularExpressions;

namespace CollatzConjecture.Math
{
    public static class NumericExtensions
    {
        public static bool IsNumeric(this string line)
        {
            return Regex.IsMatch(line, @"^\d+$");
        }

        public static List<string> SplitNumericToParts(this string line, int numbersInPart, bool addOneToBegin = false, bool addZero = false)
        {
            List<string> parts = new List<string>();
            if (string.IsNullOrEmpty(line))
                return parts;
            int nextIndex = 0;
            bool isPrevNotEven = false;
            while (true)
            {
                if (nextIndex == line.Length)
                    break;
                string splitedLine = string.Empty;
                if (nextIndex + numbersInPart > line.Length)
                    splitedLine = line.Substring(nextIndex, line.Length - nextIndex);
                else
                    splitedLine = line.Substring(nextIndex, numbersInPart);
                if (addOneToBegin && isPrevNotEven)
                    splitedLine = splitedLine.Insert(0, "1");
                else if (addZero && (splitedLine[0] == '1' || IsAddZero(splitedLine)) && nextIndex != 0)
                    splitedLine = splitedLine.Insert(0, "0");

                parts.Add(splitedLine);
                isPrevNotEven = !splitedLine.IsEven();
                nextIndex += numbersInPart;
                if (nextIndex > line.Length)
                    break;
            }
            return parts;
        }

        private static bool IsAddZero(string line)
        {
            bool isAddZero = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Equals('0'))
                {
                    isAddZero = true;
                    continue;
                }
                if (line[i].Equals('1') && isAddZero && line.Length > i + 1)
                    return true;
                return false;
            }
            return false;
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
                //else if (prevLine[i] == '1' && isPrevZero )
                //{
                //    isPrevZero = false;
                //    number = number.Insert(0, "0");
                //}
                else
                    break;
            }
            return number;
        }
    }
}
