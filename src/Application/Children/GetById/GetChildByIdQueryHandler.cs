using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Children.Get;
using Domain.Children;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Children.GetById;

internal sealed class GetChildByIdQueryHandler(
    IApplicationDbContext context,
    IUserContext userContext)
    : IQueryHandler<GetChildByIdQuery, ChildResponse>
{
    public async Task<Result<ChildResponse>> Handle(
        GetChildByIdQuery query,
        CancellationToken cancellationToken)
    {
        ChildResponse? child = await context.Children
            .Where(c => c.Id == query.ChildId && c.UserId == userContext.UserId)
            .Select(c => new ChildResponse(
                c.Id,
                c.Name,
                c.IsCheckedIn,
                c.CreatedAt,
                c.CheckedInAt))
            .FirstOrDefaultAsync(cancellationToken);

        if (child is null)
        {
            return Result.Failure<ChildResponse>(ChildErrors.NotFound);
        }

        return child;
    }
}
