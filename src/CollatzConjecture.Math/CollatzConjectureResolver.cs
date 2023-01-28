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

        public List<string> ResolveConjecture(string number)
        {
            List<string> result = new List<string>();
            result.Add(number);
            while (number != "1")
            {
                if(number.IsEven())
                    number = math.DivisionBy2(number);
                else
                    number = math.Math3X(number);
                result.Add(number);
            }
            return result;
        }
    }
}
