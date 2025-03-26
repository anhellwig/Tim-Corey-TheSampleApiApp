using TheSampleApi.Data;

namespace TheSampleApi.Startup;

public static class DependenciesConfig
{
    public static void AddDependencies(this IHostApplicationBuilder builder)
    {
        builder.Services.AddCorsServices()
            .AddOpenApiServices()
            .AddTransient<CourseData>();
    }
}
