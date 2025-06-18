using MongoDB.Driver;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;
using RealEstateCam.Infrastructure.Persistence;

namespace RealEstateCam.Infrastructure.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly IMongoCollection<PropertyImage> _collection;

        public PropertyImageRepository(MongoDbContext context)
        {
            _collection = context.PropertyImages;
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var propertyImageFilterDefinition = FilterByObjectId(id);

            var resultDelete = await _collection.DeleteOneAsync(propertyImageFilterDefinition);

            return resultDelete.DeletedCount > 0;
        }

        public async Task<PropertyImage> GetById(Guid id)
        {
            var propertyImage = await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            return propertyImage;
        }

        public async Task<PropertyImage> GetByIdProperty(Guid idProperty)
        {
            var propertyImage = await _collection
                .Find(x => x.IdProperty == idProperty)
                .SortByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync();

            return propertyImage;
        }

        public async Task<PropertyImage> InsertOne(PropertyImage propertyImage)
        {
            await _collection.InsertOneAsync(propertyImage);

            return propertyImage;
        }
        public async Task<List<PropertyImage>> GetAll()
        {
            var propertyImages = await _collection
                .Find(EmptyFilter())
                .ToListAsync();

            return propertyImages;
        }

        private static FilterDefinition<PropertyImage> FilterByObjectId(Guid id)
        {
            return Builders<PropertyImage>.Filter.Eq(x => x.Id, id);
        }

        private static FilterDefinition<PropertyImage> EmptyFilter()
        {
            return Builders<PropertyImage>.Filter.Empty;
        }

    }
}
