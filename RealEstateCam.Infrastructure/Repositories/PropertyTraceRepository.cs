using MongoDB.Driver;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;
using RealEstateCam.Infrastructure.Persistence;

namespace RealEstateCam.Infrastructure.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly IMongoCollection<PropertyTrace> _collection;

        public PropertyTraceRepository(MongoDbContext context)
        {
            _collection = context.PropertyTraces;
        }

        public async Task<PropertyTrace> AddAsync(PropertyTrace trace)
        {
            await _collection.InsertOneAsync(trace);

            return trace;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var propertyTrace = FilterByObjectId(id);

            var resultDelete = await _collection.DeleteOneAsync(propertyTrace);

            return resultDelete.DeletedCount > 0;
        }

        public async Task<PropertyTrace?> GetByIdAsync(Guid id)
        {
            var propertyTrace = await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            return propertyTrace;
        }

        public async Task<List<PropertyTrace>> GetByPropertyIdAsync(Guid propertyId)
        {
            var propertyTraces = await _collection
                .Find(x => x.IdProperty == propertyId)
                .ToListAsync();

            return propertyTraces;
        }

        public async Task<PropertyTrace> UpdateAsync(PropertyTrace trace)
        {
            await _collection.ReplaceOneAsync(x => x.Id == trace.Id, trace);

            return trace;
        }

        private static FilterDefinition<PropertyTrace> FilterByObjectId(Guid id)
        {
            return Builders<PropertyTrace>.Filter.Eq(x => x.Id, id);
        }

        private static FilterDefinition<PropertyTrace> EmptyFilter()
        {
            return Builders<PropertyTrace>.Filter.Empty;
        }
    }
}
