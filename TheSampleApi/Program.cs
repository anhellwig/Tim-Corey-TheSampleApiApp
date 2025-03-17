using TheSampleApi.Endpoints;
using TheSampleApi.Startup;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

WebApplication app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.MapRootEndpoint();
app.MapCourseEndpoints();

app.Run();
