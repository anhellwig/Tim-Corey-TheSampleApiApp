namespace TheSampleApi.Endpoints;

public static class RootEndpoint
{
    public static void MapRootEndpoint(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}
