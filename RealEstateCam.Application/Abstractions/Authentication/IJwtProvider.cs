using RealEstateCam.Domain.Entities.Users;

namespace RealEstateCam.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
