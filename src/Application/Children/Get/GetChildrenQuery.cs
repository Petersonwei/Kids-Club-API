using Application.Abstractions.Messaging;

namespace Application.Children.Get;

public sealed record GetChildrenQuery : IQuery<List<ChildResponse>>;
