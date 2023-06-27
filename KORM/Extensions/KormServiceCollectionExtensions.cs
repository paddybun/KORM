using KORM.Interfaces;
using KORM.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KORM.Extensions;

public static class KormServiceCollectionExtensions
{
    public static IServiceCollection AddKorm(this IServiceCollection serviceCollection, IKustoConnectionOptions options)
    {
        serviceCollection.AddScoped<IKustoConnector, KustoConnector>(
            x => ActivatorUtilities.CreateInstance<KustoConnector>(x, options));
        serviceCollection.AddScoped<IKustoDatabase, KustoDatabase>();
        return serviceCollection;
    }
}