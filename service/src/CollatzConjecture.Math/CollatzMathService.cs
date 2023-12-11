using CollatzConjecture.Math.Calc;
using CollatzConjecture.Math.Converters;
using CollatzConjecture.Math.Exception;
using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math
{
    public class CollatzMathService : ICollatzMathService
    {
        private readonly CollatzCalc _calc;
        private readonly DivisionConverter _divisionConverter;
        private readonly MultiplicationConverter _multiplicationConverter;

        public CollatzMathService(CollatzCalc calc, DivisionConverter divisionConverter,MultiplicationConverter multiplicationConverter )
        {
            _calc = calc;
            _divisionConverter = divisionConverter;
            _multiplicationConverter = multiplicationConverter;
        }

        public async Task<string> DivisionBy2(string number)
        {
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            number = number.Replace(" ", "");
            string result = string.Empty;
            var numbers = _divisionConverter.ConvertToLongNumber(number);
            NumericPart? item = numbers.GetFirst();
            while (item != null)
            {
                result += (await _calc.Division(item)).Result;
                item = item.Next;
            }
            return result;
        }

        public async Task<string> Multiplication(string number, int multiplier, bool isSubtraction)
        {
            if (!number.IsNumeric())
                throw new NotNumericException(number);
            string result = string.Empty;
            var longValue = _multiplicationConverter.ConvertToLongNumber(number);
            var item = longValue.GetLast();
            CalculationResult prevResult = null;
            while (item != null)
            {
                var res = await _calc.Multiplication(new MultiplicationArgs(item, multiplier, isSubtraction, prevResult));
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
