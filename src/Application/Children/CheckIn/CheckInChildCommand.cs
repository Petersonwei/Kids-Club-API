using Application.Abstractions.Messaging;

namespace Application.Children.CheckIn;

public sealed record CheckInChildCommand(Guid ChildId) : ICommand;
