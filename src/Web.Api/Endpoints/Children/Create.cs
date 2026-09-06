using Application.Abstractions.Messaging;
using Application.Children.Create;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Children;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public string Name { get; set; } = string.Empty;
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("children", async (
            Request request,
            ICommandHandler<CreateChildCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateChildCommand(request.Name);

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Children)
        .Produces<Guid>()
        .RequireAuthorization();
    }
}
