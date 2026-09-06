using Application.Abstractions.Messaging;
using Application.Children.CheckIn;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Children;

internal sealed class CheckOut : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("children/{id:guid}/check-out", async (
            Guid id,
            ICommandHandler<CheckInChildCommand> handler,
            CancellationToken cancellationToken) =>
        {
            // Uses the same handler as check-in (toggles status)
            var command = new CheckInChildCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Children)
        .Produces(StatusCodes.Status204NoContent)
        .RequireAuthorization();
    }
}
