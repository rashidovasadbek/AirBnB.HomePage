using AirBnB.Api.Data;

namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddExposers().AddDevTools().AddIdentityInfrastructure().AddCors().AddCaching().AddMapping();
        return new();
    }

    //https://localhost:7134/api/locations?Category=Arctic&PageSize=4&PageToken=1 // swagger
    //https://localhost:7134/api/location?pageSize=4&pageToken=1&category=Arctic

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.SeedDataAsync();
        app.UseExposers().UseDevTools().UseCors().UseStaticFiles();
        return app;
    }
}