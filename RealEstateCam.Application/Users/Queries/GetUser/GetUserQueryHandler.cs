using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Users.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Users;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Users.Queries.GetUser
{
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.IdUser);
            if (user is null)
                return Result.Failure<UserDto>(UserErrors.NotFound);

            var dto = _mapper.Map<UserDto>(user);
            return Result.Success(dto);
        }
    }
}
