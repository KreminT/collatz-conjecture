using CollatzConjecture.Math;

namespace CollatzConjecture.Configuration;

public class AppConfiguration:IResolverConfiguration
{
    private readonly IConfiguration _configuration;

    public AppConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public int NumberLength => _configuration.GetValue<int>("app:number_length");
}