using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ta.UIKit.Nodes;

namespace ta.UIKit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureUIKitCore(this IServiceCollection services)
    {
        services.TryAddTransient(typeof(NodePool<>));
        services.TryAddSingleton(typeof(NodeFactory<>), typeof(ServiceProviderNodeFactory<>));
        services.AddSingleton<NodeFactory>();

        return services;
    }
}
