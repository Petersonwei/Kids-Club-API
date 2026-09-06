using SharedKernel;

namespace Domain.Children;

public sealed record ChildCheckedInDomainEvent(Guid ChildId) : IDomainEvent;
