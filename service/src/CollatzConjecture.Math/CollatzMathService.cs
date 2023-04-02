using CollatzConjecture.Math.Converters;
using CollatzConjecture.Math.Exception;
using CollatzConjecture.Math.Model;

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
            var numbers = new DivisionConverter().ConvertToLongNumber(number, 8);
            NumericPart? item = numbers.GetFirst();
            while (item != null)
            {
                string res = string.Empty;
                if (item.Value > 1)
                {
                    res = ((int)item.Value / 2).ToString();
                    if (item.ValueString[0] == '0')
                        res = res.AddZerosIfExists(item.ValueString);
                }
                else
                    res = res.AddZeros(item.ValueString.Length);
                result += res;
                item = item.Next;
            }
            return result;
        }

        public string Multiplication(string number, int multiplier)
        {
            int partLength = 8;
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            string result = string.Empty;
            int prevValue = 0;
            var longValue = new MultiplicationConverter().ConvertToLongNumber(number, partLength);
            var item = longValue.GetLast();
            while (item != null)
            {
                int value = item.Value * 3;
                if (item.Next == null)
                    value += 1;
                value += prevValue;
                string val = value.ToString();
                val = val.AddZeros(item.ValueString.Length);
                if (val.Length > item.ValueString.Length)
                    prevValue = int.Parse(val.Substring(0, val.Length - item.ValueString.Length));
                else
                    prevValue = 0;
                if (item.Prev == null)
                    result = result.Insert(0, val);
                else
                    result = result.Insert(0, val.Substring(val.Length - item.ValueString.Length, item.ValueString.Length));
                item = item.Prev;
            }
            return result;
        }
    }
}
