using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Owners.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Owners.Queries.GetOwner
{
    internal sealed class GetOwnerQueryHandler : IQueryHandler<GetOwnerQuery, OwnerDto>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public GetOwnerQueryHandler(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<Result<OwnerDto>> Handle(GetOwnerQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetById(request.IdOwner);

            if(owner is null)
                return Result.Failure<OwnerDto>(OwnerError.NotFound);

            var dto = _mapper.Map<OwnerDto>(owner);
            return Result.Success(dto);
        }
    }
}
