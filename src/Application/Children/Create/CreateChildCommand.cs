using Application.Abstractions.Messaging;

namespace Application.Children.Create;

public sealed record CreateChildCommand(string Name) : ICommand<Guid>;
