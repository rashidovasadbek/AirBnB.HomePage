using AirBnB.Api.Data;

namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddExposers().AddDevTools().AddIdentityInfrastructure().AddCors().AddCaching().AddMapping();
        return new();
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.SeedDataAsync();
        app.UseExposers().UseDevTools().UseCors().UseStaticFiles();
        return app;
    }
}