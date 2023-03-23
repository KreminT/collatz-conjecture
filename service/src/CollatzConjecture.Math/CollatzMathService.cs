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
            var numbers = number.SplitNumericToParts(8, true, true);
            foreach (var item in numbers)
            {
                int digit = int.Parse(item);
                string res = string.Empty;
                if (digit > 1)
                {
                    res = ((int)digit / 2).ToString();
                    if (item[0] == '0')
                        res = res.AddZerosIfExists(item);
                }
                else
                    res = res.AddZeros(item.Length);
                result += res;
            }
            return result;
        }

        public string Math3X(string number)
        {
            int partLength = 8;
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
