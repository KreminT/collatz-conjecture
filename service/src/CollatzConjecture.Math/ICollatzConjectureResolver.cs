using CollatzConjecture.Math.IO;
using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math
{
    public interface ICollatzConjectureResolver
    {
        Task ResolveConjecture(IResolverArgs args, IResultProcessor processor);
    }
}
