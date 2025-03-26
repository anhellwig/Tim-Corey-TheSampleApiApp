namespace TheSampleApi.Startup;

public static class CorsConfig
{
    private const string AllowAllPolicyName = "AllowAll";

    public static IServiceCollection AddCorsServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowAllPolicyName, policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });

        return services;
    }

    public static void UseCorsConfig(this WebApplication app)
    {
        app.UseCors(AllowAllPolicyName);
    }
}
