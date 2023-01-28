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
            foreach(var item in number)
            {
                if (residual > 0)
                    digit = int.Parse($"{residual}{item}");
                else if (digit > 0)
                    digit = int.Parse($"{digit}{item}");
                else
                    digit = int.Parse(item.ToString());
                if (digit < 2)
                {
                    if (!string.IsNullOrEmpty(result))
                        result += "0";
                    continue;
                }
                int value = digit / 2;
                result += value.ToString();
                residual = digit % 2;
                digit = 0;
            }
            return result;
        }

        public string Math3X(string number)
        {
            int partLength= 8;
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            number = number.Replace(" ", "");
            string result = string.Empty;
            int prevValue = 0;
            List<string> numbers = number.SplitNumericToParts(partLength);
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                int value = int.Parse(numbers[i]) * 3;
                if (i == numbers.Count - 1)
                    value += 1;
                value += prevValue;
                string val = value.ToString();
                val = val.AddZeros(numbers[i].Length);
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
