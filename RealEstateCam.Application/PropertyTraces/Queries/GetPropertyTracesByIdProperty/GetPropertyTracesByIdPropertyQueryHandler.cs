using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyTraces.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyTraces.Queries.GetPropertyTracesByIdProperty
{
    internal sealed class GetPropertyTracesByIdPropertyQueryHandler : IQueryHandler<GetPropertyTracesByIdPropertyQuery, IReadOnlyList<PropertyTraceDto>>
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetPropertyTracesByIdPropertyQueryHandler(IPropertyTraceRepository propertyTraceRepository, IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyTraceRepository = propertyTraceRepository;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<PropertyTraceDto>>> Handle(GetPropertyTracesByIdPropertyQuery request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetById(request.IdProperty);

            if(property is null)
                return Result.Failure<IReadOnlyList<PropertyTraceDto>>(PropertyTraceError.NotFound);

            var propertyTraces = await _propertyTraceRepository.GetByPropertyIdAsync(property.Id);

            var dto = _mapper.Map<IReadOnlyList<PropertyTraceDto>>(propertyTraces);

            return Result.Success(dto);
        }
    }
}
