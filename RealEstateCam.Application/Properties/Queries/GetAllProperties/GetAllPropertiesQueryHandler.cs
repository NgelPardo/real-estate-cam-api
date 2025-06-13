using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Queries.GetAllProperties
{
    internal sealed class GetAllPropertiesQueryHandler : IQueryHandler<GetAllPropertiesQuery, IReadOnlyList<PropertyDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetAllPropertiesQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<PropertyDto>>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAll();

            var result = _mapper.Map<IReadOnlyList<PropertyDto>>(properties);

            return Result.Success(result);
        }
    }
}
