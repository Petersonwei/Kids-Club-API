using Application.Abstractions.Messaging;
using Application.Children.Get;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Children;

internal sealed class Get : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("children", async (
            IQueryHandler<GetChildrenQuery, List<ChildResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetChildrenQuery();

            Result<List<ChildResponse>> result = await handler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Children)
        .Produces<List<ChildResponse>>()
        .RequireAuthorization();
    }
}
