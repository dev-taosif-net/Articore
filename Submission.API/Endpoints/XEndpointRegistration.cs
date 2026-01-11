namespace Submission.API.Endpoints;

public static class XEndpointRegistration
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
       app.MapCreateArticle();
        
       return app;
    }
    
}