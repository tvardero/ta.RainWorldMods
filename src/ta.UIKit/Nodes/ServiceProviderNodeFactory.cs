using Microsoft.Extensions.DependencyInjection;

namespace ta.UIKit.Nodes;

public class ServiceProviderNodeFactory<TNode> : NodeFactory<TNode>
where TNode : Node
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceProviderNodeFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public override TNode Create()
    {
        var node = ActivatorUtilities.GetServiceOrCreateInstance<TNode>(_serviceProvider);
        node.Initialize();

        return node;
    }
}
