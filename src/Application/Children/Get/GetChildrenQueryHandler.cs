using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Children.Get;

internal sealed class GetChildrenQueryHandler(
    IApplicationDbContext context,
    IUserContext userContext)
    : IQueryHandler<GetChildrenQuery, List<ChildResponse>>
{
    public async Task<Result<List<ChildResponse>>> Handle(
        GetChildrenQuery query,
        CancellationToken cancellationToken)
    {
        List<ChildResponse> children = await context.Children
            .Where(c => c.UserId == userContext.UserId)
            .Select(c => new ChildResponse(
                c.Id,
                c.Name,
                c.IsCheckedIn,
                c.CreatedAt,
                c.CheckedInAt))
            .ToListAsync(cancellationToken);

        return children;
    }
}
