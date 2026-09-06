using SharedKernel;

namespace Domain.Children;

public sealed record ChildCreatedDomainEvent(Guid ChildId) : IDomainEvent;
