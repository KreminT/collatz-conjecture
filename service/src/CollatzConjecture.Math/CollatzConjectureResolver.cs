using CollatzConjecture.Math.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollatzConjecture.Math
{
    public class CollatzConjectureResolver : ICollatzConjectureResolver
    {
        private readonly ICollatzMathService math;

        public CollatzConjectureResolver(ICollatzMathService math)
        {
            this.math = math;
        }

        public async Task<List<string>> ResolveConjecture(string number)
        {
            List<string> result = new List<string>();
            result.Add(number);
            while (number != "1")
            {
                if (number.IsEven())
                    number = await math.DivisionBy2(number);
                else
                    number = math.Multiplication(number, 3);
                result.Add(number);
            }
            return result;
        }

        public async Task<string> ResolveConjecture(string number, IResultProcessor processor)
        {
            processor.Write(number);
            while (number != "1")
            {
                if (number.IsEven())
                    number = await math.DivisionBy2(number);
                else
                    number = math.Multiplication(number, 3);
                processor.Write(number);
            }
            return processor.GetFileName();
        }
    }
}
