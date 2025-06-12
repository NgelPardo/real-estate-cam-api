using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Users;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Users.Commands.RegisterUser
{
    internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            bool isUserExist = await _userRepository.IsUserExists(request.Email);

            if (isUserExist)
                return Result.Failure<Guid>(UserErrors.AlreadyExists);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User user = User.Create(
                request.Nombre,
                request.Apellido,
                request.Email,
                passwordHash
            );

            var result = await _userRepository.Add( user );

            return user.Id!;
        }
    }
}
