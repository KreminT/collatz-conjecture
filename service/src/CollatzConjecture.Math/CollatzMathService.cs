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
                result += (await resolver.Resolve(item)).Result;
                item = item.Next;
            }
            return result;
        }

        public async Task<string> Multiplication(string number, int multiplier)
        {
            int partLength = 8;
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            string result = string.Empty;
            int prevValue = 0;
            var longValue = new MultiplicationConverter().ConvertToLongNumber(number, partLength);
            var item = longValue.GetLast();
            MultiplicationMathResolver resolver = new MultiplicationMathResolver();
            MathResult prevResult = null;
            while (item != null)
            {
                var res = await resolver.Resolve(item, prevResult);
                if (item.Prev == null)
                    result = result.Insert(0, res.Result);
                else
                    result = result.Insert(0, res.Result.Substring(res.Result.Length - item.ValueString.Length, item.ValueString.Length));
                item = item.Prev;
                prevResult = res;
            }
            return result;
        }
    }
}
