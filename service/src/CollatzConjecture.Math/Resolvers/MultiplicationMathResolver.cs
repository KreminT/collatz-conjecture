using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Resolvers;

public class MultiplicationMathResolver : IMathResolver
{
    public Task<MathResult> Resolve(NumericPart item, int multiplier, MathResult prevResult = null)
    {
        MathResult result = new MathResult();
        int value = item.Value * multiplier;
        if (item.Next == null)
            value += 1;
        value += prevResult?.Remainder ?? 0;
        string val = value.ToString();
        val = val.AddZeros(item.ValueString.Length);
        if (val.Length > item.ValueString.Length)
            result.Remainder = int.Parse(val.Substring(0, val.Length - item.ValueString.Length));

        result.Result = val;
        return Task.FromResult(result);
    }
}