using RealEstateCam.Domain.Entities.Users;

namespace RealEstateCam.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> IsUserExists(
            string email,
            CancellationToken cancellationToken = default
        );
        Task<User> Add(User user);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
