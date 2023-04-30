using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Resolvers;

public interface IMathResolver
{
    Task<MathResult> Resolve(NumericPart part, int multiplier, MathResult prevResult = null);
}