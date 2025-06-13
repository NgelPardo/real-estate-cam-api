using MongoDB.Driver;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Interfaces.Repositories;
using RealEstateCam.Infrastructure.Persistence;
using System;

namespace RealEstateCam.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IMongoCollection<Owner> _collection;

        public OwnerRepository(MongoDbContext context)
        {
            _collection = context.Owners;
        }

        public async Task<List<Owner>> GetAll()
        {
            var entities = await _collection
                .Find(EmptyFilter())
                .ToListAsync();

            return entities;
        }

        public async Task<Owner> GetById(Guid id)
        {
            var owner = await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            return owner;
        }

        public async Task<Owner> InsertOne(Owner owner)
        {
            await _collection.InsertOneAsync(owner);

            return owner;
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var ownerFilterDefinition = FilterByObjectId(id);
        
            var resultDelete = await _collection.DeleteOneAsync(ownerFilterDefinition);

            return resultDelete.DeletedCount > 0;
        }

        public Task<Owner> UpdateOne(Owner owner)
        {
            throw new NotImplementedException();
        }

        private static FilterDefinition<Owner> FilterByObjectId(Guid id)
        {
            return Builders<Owner>.Filter.Eq(x => x.Id, id);
        }

        private static FilterDefinition<Owner> EmptyFilter()
        {
            return Builders<Owner>.Filter.Empty;
        }
    }
}
