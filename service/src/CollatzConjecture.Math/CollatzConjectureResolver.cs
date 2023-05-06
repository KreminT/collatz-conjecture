using CollatzConjecture.Math.IO;

namespace CollatzConjecture.Math
{
    public class CollatzConjectureResolver : ICollatzConjectureResolver
    {
        private readonly ICollatzMathService math;

        public CollatzConjectureResolver(ICollatzMathService math)
        {
            this.math = math;
        }

        public async Task ResolveConjecture(string number, int multiplier, int maxIteration, IResultProcessor processor)
        {
            HashSet<string> values = new HashSet<string>();
            while (number != "1" && !values.Contains(number) && (maxIteration==0 || values.Count<=maxIteration))
            {
                await processor.Write(number);
                values.Add(number);
                if (number.IsEven())
                    number = await math.DivisionBy2(number);
                else
                    number = await math.Multiplication(number, multiplier);
            }
            await processor.Write(number);
        }
    }
}
