using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Resolvers;

public interface IMathResolver
{
    Task<MathResult> Resolve(NumericPart part, MathResult prevResult = null);
}