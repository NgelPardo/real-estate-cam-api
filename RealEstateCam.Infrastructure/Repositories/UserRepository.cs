using MongoDB.Driver;
using RealEstateCam.Domain.Entities.Users;
using RealEstateCam.Domain.Interfaces.Repositories;
using RealEstateCam.Infrastructure.Persistence;

namespace RealEstateCam.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(MongoDbContext context)
        {
            _collection = context.Users;
        }

        public async Task<User> Add(User user)
        {
            await _collection.InsertOneAsync(user);

            return user;
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = await _collection
                .Find(x => x.Email == email)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> IsUserExists(string email, CancellationToken cancellationToken = default)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            return await _collection.Find(filter).AnyAsync(cancellationToken);
        }
    }
}
