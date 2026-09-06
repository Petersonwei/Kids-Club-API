using Application.Abstractions.Messaging;
using Application.Children.Delete;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Children;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("children/{id:guid}", async (
            Guid id,
            ICommandHandler<DeleteChildCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteChildCommand(id);

            Result result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Children)
        .Produces(StatusCodes.Status204NoContent)
        .RequireAuthorization();
    }
}
