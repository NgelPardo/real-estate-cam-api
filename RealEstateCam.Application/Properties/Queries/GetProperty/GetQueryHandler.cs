using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Queries.GetProperty
{
    internal sealed class GetQueryHandler : IQueryHandler<GetPropertyQuery, PropertyDto>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Result<PropertyDto>> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetById(request.IdProperty);
            if(property is null)
                return Result.Failure<PropertyDto>(PropertyError.NotFound);

            var dto = _mapper.Map<PropertyDto>(property);
            return Result.Success(dto);
        }
    }
}
