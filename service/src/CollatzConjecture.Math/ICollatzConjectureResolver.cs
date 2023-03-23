using CollatzConjecture.Math.IO;

namespace CollatzConjecture.Math
{
    public interface ICollatzConjectureResolver
    {
        List<string> ResolveConjecture(string number);
        string ResolveConjecture(string number, IResultProcessor processor);
    }
}
