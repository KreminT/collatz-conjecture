using CollatzConjecture.Math.IO;
using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math
{
    public class CollatzConjectureResolver : ICollatzConjectureResolver
    {
        private readonly ICollatzMathService math;

        public CollatzConjectureResolver(ICollatzMathService math)
        {
            this.math = math;
        }

        public async Task ResolveConjecture(IResolverArgs args, IResultProcessor processor)
        {
            HashSet<string> values = new HashSet<string>();
            string number = args.Value;
            while (number != "1" && !values.Contains(number) && (args.MaxIteration == 0 || values.Count <= args.MaxIteration))
            {
                await processor.Write(number);
                values.Add(number);
                if (number.IsEven())
                    number = await math.DivisionBy2(number);
                else
                    number = await math.Multiplication(number, args.Multiplier);
            }
            await processor.Write(number);
        }
    }
}
