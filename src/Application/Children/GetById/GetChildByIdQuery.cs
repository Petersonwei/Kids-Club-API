using Application.Abstractions.Messaging;
using Application.Children.Get;

namespace Application.Children.GetById;

public sealed record GetChildByIdQuery(Guid ChildId) : IQuery<ChildResponse>;
