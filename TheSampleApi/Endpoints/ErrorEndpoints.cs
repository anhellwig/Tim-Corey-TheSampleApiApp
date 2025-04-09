namespace TheSampleApi.Endpoints;

public static class ErrorEndpoints
{
    public static void MapErrorEndpoints(this WebApplication app)
    {
        app.MapGet("/error/{code:int}", (int code) => code switch
        {
            400 => Results.Problem(detail: "Some problem occurred.", statusCode: 400),
            _ => Results.StatusCode(code)
        });
    }
}
