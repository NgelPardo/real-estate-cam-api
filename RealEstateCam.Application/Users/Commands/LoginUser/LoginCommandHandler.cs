using AutoMapper;
using RealEstateCam.Application.Abstractions.Authentication;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Users.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Users;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Users.Commands.LoginUser
{
    internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        public async Task<Result<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null)
                return Result.Failure<LoginDto>(UserErrors.NotFound);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Result.Failure<LoginDto>(UserErrors.InvalidCredentials);

            string token = await _jwtProvider.GenerateTokenAsync(user);

            var dto = _mapper.Map<LoginDto>((user, token));

            return Result.Success(dto);
        }
    }
}
