using CollatzConjecture.Math.IO;

namespace CollatzConjecture.Math
{
    public interface ICollatzConjectureResolver
    {
        Task ResolveConjecture(string number, int multiplier,int maxIteration, IResultProcessor processor);
    }
}
