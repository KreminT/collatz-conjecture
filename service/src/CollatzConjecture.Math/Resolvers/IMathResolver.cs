using CollatzConjecture.Math.Model;

namespace CollatzConjecture.Math.Resolvers;

public interface IMathResolver
{
    string Result { get; }
    Task<string> Resolve(NumericPart part);
}