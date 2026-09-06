using Application.Abstractions.Messaging;

namespace Application.Children.Delete;

public sealed record DeleteChildCommand(Guid ChildId) : ICommand;
