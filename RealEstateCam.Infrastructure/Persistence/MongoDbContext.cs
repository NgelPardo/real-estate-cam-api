using RealEstateCam.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Entities.Users;
using RealEstateCam.Domain.Entities.Owners;

namespace RealEstateCam.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDBSettings> mongoDBSettingsOptions)
        {
            var client = new MongoClient(mongoDBSettingsOptions.Value.MONGO_URI);

            var conventionPack = new ConventionPack
            {
                new GuidConvention()
            };

            ConventionRegistry.Register(nameof(GuidConvention.Name), conventionPack, t => true);

            _database = client.GetDatabase(mongoDBSettingsOptions.Value.DATABASE_NAME);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("users");
        public IMongoCollection<Property> Properties => _database.GetCollection<Property>("properties");
        public IMongoCollection<Owner> Owners => _database.GetCollection<Owner>("owners");
        public IMongoCollection<PropertyImage> PropertyImages => _database.GetCollection<PropertyImage>("property_images");
        public IMongoCollection<PropertyTrace> PropertyTraces=> _database.GetCollection<PropertyTrace>("property_traces");
    }
}
