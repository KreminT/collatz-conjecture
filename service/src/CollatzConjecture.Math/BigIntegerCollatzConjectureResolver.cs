using System.Numerics;
using CollatzConjecture.Math.IO;
using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math;

public class BigIntegerCollatzConjectureResolver : ICollatzConjectureResolver
{
    public async Task ResolveConjecture(IResolverArgs args, IResultProcessor processor)
    {
        HashSet<BigInteger> values = new HashSet<BigInteger>();
        BigInteger number = BigInteger.Parse(args.Value);
        while (number != BigInteger.One && !values.Contains(number) && (args.MaxIteration == 0 || values.Count <= args.MaxIteration))
        {
            await processor.Write(number.ToString());
            values.Add(number);
            if (number.IsEven)
                number = BigInteger.Divide(number, 2);
            else
            {
                number = BigInteger.Multiply(number, args.Multiplier);
                if (args.IsSubtraction)
                    number = BigInteger.Subtract(number, 1);
                else
                    number = BigInteger.Add(number, 1);
            }
        }
        await processor.Write(number.ToString());
    }
}