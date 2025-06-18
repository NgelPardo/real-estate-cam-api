using MongoDB.Driver;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;
using RealEstateCam.Infrastructure.Persistence;

namespace RealEstateCam.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Property> _collection;

        public PropertyRepository(MongoDbContext context)
        {
            _collection = context.Properties;
        }

        public async Task<Guid> DeleteOne(Guid id)
        {
            var property = FilterByObjectId(id);

            await _collection.DeleteOneAsync(property);

            return id;
        }

        public async Task<List<Property>> GetAll()
        {
            var properties = await _collection
                .Find(EmptyFilter())
                .ToListAsync();

            return properties;
        }

        public async Task<List<Property>> GetByFilters(string? name, string? address, decimal? minPrice, decimal? maxPrice)
        {
            var builder = Builders<Property>.Filter;
            var filters = new List<FilterDefinition<Property>>();

            if (!string.IsNullOrWhiteSpace(name))
                filters.Add(builder.Regex(x => x.Name, new MongoDB.Bson.BsonRegularExpression(name, "i")));

            if (!string.IsNullOrWhiteSpace(address))
                filters.Add(builder.Regex(x => x.Address, new MongoDB.Bson.BsonRegularExpression(address, "i")));

            if (minPrice.HasValue)
                filters.Add(builder.Gte(x => x.Price, minPrice.Value));

            if (maxPrice.HasValue)
                filters.Add(builder.Lte(x => x.Price, maxPrice.Value));

            var combinedFilter = filters.Any() ? builder.And(filters) : builder.Empty;

            return await _collection.Find(combinedFilter).ToListAsync();
        }

        public async Task<Property> GetById(Guid id)
        {
            var property = await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            return property;
        }

        public async Task<Guid> InsertOne(Property property)
        {
            await _collection.InsertOneAsync(property);

            return property.Id;
        }

        public async Task<Property> UpdateOne(Property property)
        {
            await _collection.ReplaceOneAsync(x => x.Id == property.Id, property);

            return property;
        }

        private static FilterDefinition<Property> FilterByObjectId(Guid id)
        {
            return Builders<Property>.Filter.Eq(x => x.Id, id);
        }

        private static FilterDefinition<Property> EmptyFilter()
        {
            return Builders<Property>.Filter.Empty;
        }
    }
}
