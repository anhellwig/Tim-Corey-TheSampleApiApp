using TheSampleApi.Data;

namespace TheSampleApi.Startup;

public static class DependenciesConfig
{
    public static void AddDependencies(this IHostApplicationBuilder builder)
    {
        builder.Services
            .AddOpenApiServices()
            .AddCorsServices()
            .AddAllHealthChecks()
            .AddTransient<CourseData>();
    }
}
