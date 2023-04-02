using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Resolvers;

public interface IMathResolver
{
    Task<string> Resolve(NumericPart part);
}