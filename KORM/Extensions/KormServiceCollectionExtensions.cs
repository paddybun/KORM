using KORM.Interfaces;
using KORM.Service;
using Microsoft.Extensions.DependencyInjection;

namespace KORM.Extensions;

public static class KormServiceCollectionExtensions
{
    public static IServiceCollection AddKorm(this IServiceCollection me, IKustoConnectionOptions options)
    {
        me.AddScoped<IKustoConnector, KustoConnector>(
            x => ActivatorUtilities.CreateInstance<KustoConnector>(x, options));
        return me;
    }
}