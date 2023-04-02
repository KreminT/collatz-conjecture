using CollatzConjecture.Math.Converters;
using CollatzConjecture.Math.Exception;
using CollatzConjecture.Math.Model;
using CollatzConjecture.Math.Resolvers;

namespace CollatzConjecture.Math
{
    public class CollatzMathService : ICollatzMathService
    {
        public async Task<string> DivisionBy2(string number)
        {
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            number = number.Replace(" ", "");
            string result = string.Empty;
            var numbers = new DivisionConverter().ConvertToLongNumber(number, 8);
            NumericPart? item = numbers.GetFirst();
            IMathResolver resolver = new DivisionResolver();
            while (item != null)
            {
                result +=  await resolver.Resolve(item);
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
