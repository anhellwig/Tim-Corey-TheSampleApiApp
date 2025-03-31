using TheSampleApi.Endpoints;
using TheSampleApi.Startup;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

WebApplication app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.UseCorsConfig();

app.MapAllHealthChecks();

app.MapRootEndpoint();
app.MapCourseEndpoints();

app.Run();
