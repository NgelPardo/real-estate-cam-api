using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyTraces.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyTraces.Queries.GetPropertyTrace
{
    internal sealed class GetPropertyTraceQueryHandler : IQueryHandler<GetPropertyTraceQuery, PropertyTraceDto>
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IMapper _mapper;

        public GetPropertyTraceQueryHandler(IPropertyTraceRepository propertyTraceRepository, IMapper mapper)
        {
            _propertyTraceRepository = propertyTraceRepository;
            _mapper = mapper;
        }

        public async Task<Result<PropertyTraceDto>> Handle(GetPropertyTraceQuery request, CancellationToken cancellationToken)
        {
            var propertyTrace = await _propertyTraceRepository.GetByIdAsync(request.Id);
            if(propertyTrace is null)
                return Result.Failure<PropertyTraceDto>(PropertyTraceError.NotFound);

            var dto = _mapper.Map<PropertyTraceDto>(propertyTrace);
            return Result.Success(dto);
        }
    }
}
