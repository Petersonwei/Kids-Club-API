using Application.Abstractions.Messaging;
using Application.Children.CheckIn;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Children;

internal sealed class CheckIn : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("children/{id:guid}/check-in", async (
            Guid id,
            ICommandHandler<CheckInChildCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CheckInChildCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Children)
        .Produces(StatusCodes.Status204NoContent)
        .RequireAuthorization();
    }
}
