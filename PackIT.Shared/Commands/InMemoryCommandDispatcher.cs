using Microsoft.Extensions.DependencyInjection;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Shared.Commands;

internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _provider;

    public InMemoryCommandDispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }
    
    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = _provider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command);
    }
}