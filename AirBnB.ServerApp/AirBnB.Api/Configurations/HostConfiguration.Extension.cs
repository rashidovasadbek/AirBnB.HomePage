using System.Reflection;
using AirBnB.Api.Data;
using AirBnB.Application.Services;
using AirBnB.Infrastructure.Common.Caching.Brokers;
using AirBnB.Infrastructure.Services;
using AirBnB.Infrastructure.Settings;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.DataContext;
using AirBnB.Persistence.Repositories;
using AirBnB.Persistence.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;
    
    static HostConfiguration()
    {
        Assemblies = typeof(HostConfiguration).Assembly.GetReferencedAssemblies().Select(Assembly.Load)
            .ToList();
        Assemblies.Add(typeof(HostConfiguration).Assembly);
    }
    
    private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }
    
    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        // register cache settings
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        // register lazy memory cache
        // builder.Services.AddLazyCache();

        builder.Services.AddStackExchangeRedisCache(
            options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "Caching.Airbnb";
            }
        );

        // builder.Services.AddSingleton<ICacheBroker, LazyMemoryCacheBroker>();
        builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();

        return builder;
    }
    
    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));
             
        builder.Services.AddDbContext<AirBnBdbContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        //register repositories
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
        builder.Services.AddScoped(typeof(ILocationCategoryRepository), typeof(LocationCategoryRepository));
        
        //register service
        builder.Services.AddScoped<ILocationService, LocationService>();
        builder.Services.AddScoped(typeof(ILocationCategoryService), typeof(LocationCategoryService));
        
        builder.Services.AddScoped<ICacheBroker, RedisDistributedCacheBroker>();
        
        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {

        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.AllowAnyOrigin();
                });
            });

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers().AddNewtonsoftJson();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
    
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
    
    private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        await serviceScope.ServiceProvider.InitializeSeedAsync();
        

        return app;
    }
    
    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}