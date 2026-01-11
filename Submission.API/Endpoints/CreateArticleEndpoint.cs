using MediatR;
using Submission.Application.Features.CreateArticle;

namespace Submission.API.Endpoints;

public static class CreateArticleEndpoint
{
    public static void MapCreateArticle( this IEndpointRouteBuilder app)
    {
        app.MapPost("api/articles", async (CreateArticleCommand command , ISender sender) =>
            {
                var response = await sender.Send(command);
                return Results.Created($"/api/articles/{response.Id}", response);

            })
            .RequireAuthorization(policy => policy.RequireRole("AUT"))
            .WithName("CreateArticle")
            .WithTags("Articles")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest);
    }
}