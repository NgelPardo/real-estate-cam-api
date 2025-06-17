using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Owners.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Owners.Queries.GetAllOwners
{
    internal sealed class GetAllOwnersQueryHandler : IQueryHandler<GetAllOwnersQuery, IReadOnlyList<OwnerDto>>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public GetAllOwnersQueryHandler(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<OwnerDto>>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = await _ownerRepository.GetAll();

            var result = _mapper.Map<IReadOnlyList<OwnerDto>>(owners);

            return Result.Success(result);
        }
    }
}
