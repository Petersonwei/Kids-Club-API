using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Children;
using SharedKernel;

namespace Application.Children.Create;

internal sealed class CreateChildCommandHandler(
    IApplicationDbContext context,
    IUserContext userContext)
    : ICommandHandler<CreateChildCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateChildCommand command,
        CancellationToken cancellationToken)
    {
        var child = new Child
        {
            Id = Guid.NewGuid(),
            UserId = userContext.UserId,
            Name = command.Name,
            IsCheckedIn = false,
            CreatedAt = DateTime.UtcNow
        };

        child.Raise(new ChildCreatedDomainEvent(child.Id));

        context.Children.Add(child);
        await context.SaveChangesAsync(cancellationToken);

        return child.Id;
    }
}
