using RealEstateCam.Application.Abstractions.Authentication;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Users.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Users;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Users.Commands.CheckStatus
{
    internal sealed class CheckStatusCommandHandler : ICommandHandler<CheckStatusCommand, LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public CheckStatusCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<LoginDto>> Handle(CheckStatusCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByIdAsync(request.IdUser, cancellationToken);

            if (user is null)
            {
                return Result.Failure<LoginDto>(UserErrors.NotFound);
            }

            string token = await _jwtProvider.GenerateTokenAsync(user);

            UserDto userDto = new UserDto(user.Id, user.Name!, user.LastName!, user.Email!);
            LoginDto loginDto = new LoginDto(userDto, token);

            return Result.Success(loginDto);
        }
    }
}
