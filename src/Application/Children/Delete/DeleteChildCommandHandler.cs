using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Children;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Children.Delete;

internal sealed class DeleteChildCommandHandler(
    IApplicationDbContext context,
    IUserContext userContext)
    : ICommandHandler<DeleteChildCommand>
{
    public async Task<Result> Handle(
        DeleteChildCommand command,
        CancellationToken cancellationToken)
    {
        Child? child = await context.Children
            .FirstOrDefaultAsync(
                c => c.Id == command.ChildId && c.UserId == userContext.UserId,
                cancellationToken);

        if (child is null)
        {
            return Result.Failure(ChildErrors.NotFound);
        }

        context.Children.Remove(child);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
