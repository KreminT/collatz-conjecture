using CollatzConjecture.Math.Exception;

namespace CollatzConjecture.Math
{
    public class CollatzMathService : ICollatzMathService
    {
        public string DivisionBy2(string number)
        {
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            number = number.Replace(" ", "");
            string result = string.Empty;
            int residual = 0;
            int digit = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (residual > 0)
                    digit = int.Parse($"{residual}{number[i]}");
                else if (digit > 0)
                    digit = int.Parse($"{digit}{number[i]}");
                else
                    digit = int.Parse(number[i].ToString());
                if (digit < 2)
                    continue;
                int value = digit / 2;
                result += value.ToString();
                residual = digit % 2;
                digit = 0;
            }
            return result;
        }

        public string Math3X(string number)
        {
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            number = number.Replace(" ", "");
            string result = string.Empty;
            int prevValue = 0;
            List<string> numbers = number.SplitNumericToParts(3);
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int value = int.Parse(numbers[i]) * 3;
                if (i == numbers.Count - 1)
                    value += 1;
                value += prevValue;
                string val = value.ToString();
                if (val.Length > numbers[i].Length)
                    prevValue = int.Parse(val.Substring(0, val.Length - numbers[i].Length));
                else
                    prevValue = 0;
                if (i == 0)
                    result = result.Insert(0, val);
                else
                    result = result.Insert(0, val.Substring(val.Length - numbers[i].Length, numbers[i].Length));
            }
            return result;
        }
    }
}
