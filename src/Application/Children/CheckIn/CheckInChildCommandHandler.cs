using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Children;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Children.CheckIn;

internal sealed class CheckInChildCommandHandler(
    IApplicationDbContext context,
    IUserContext userContext)
    : ICommandHandler<CheckInChildCommand>
{
    public async Task<Result> Handle(
        CheckInChildCommand command,
        CancellationToken cancellationToken)
    {
        Domain.Children.Child? child = await context.Children
            .FirstOrDefaultAsync(
                c => c.Id == command.ChildId && c.UserId == userContext.UserId,
                cancellationToken);

        if (child is null)
        {
            return Result.Failure(ChildErrors.NotFound);
        }

        // Toggle check-in status
        child.IsCheckedIn = !child.IsCheckedIn;
        child.CheckedInAt = child.IsCheckedIn ? DateTime.UtcNow : null;

        child.Raise(new ChildCheckedInDomainEvent(child.Id));

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
