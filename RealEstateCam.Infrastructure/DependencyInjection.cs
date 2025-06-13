using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateCam.Application.Mappings;
using RealEstateCam.Domain.Interfaces.Repositories;
using RealEstateCam.Infrastructure.Configuration;
using RealEstateCam.Infrastructure.Persistence;
using RealEstateCam.Infrastructure.Repositories;

namespace RealEstateCam.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var mongoSettings = new MongoDBSettings();
            configuration.GetSection(MongoDBSettings.BindName).Bind(mongoSettings);

            services.Configure<MongoDBSettings>(_ =>
            {
                _.MONGO_URI = mongoSettings.MONGO_URI;
                _.DATABASE_NAME = mongoSettings.DATABASE_NAME;
            });

            services.AddSingleton<MongoDbContext>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(typeof(OwnerMappingProfile));
            services.AddAutoMapper(typeof(PropertyMappingProfile));
            services.AddAutoMapper(typeof(UserMappingProfile));

            return services;
        }
    }
}
