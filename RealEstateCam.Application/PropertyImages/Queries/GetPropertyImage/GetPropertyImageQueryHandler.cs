using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.PropertyImages.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;


namespace RealEstateCam.Application.PropertyImages.Queries.GetPropertyImage
{
    internal sealed class GetPropertyImageQueryHandler : IQueryHandler<GetPropertyImageQuery, PropertyImageDto>
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IMapper _mapper;

        public GetPropertyImageQueryHandler(IPropertyImageRepository propertyImageRepository, IMapper mapper)
        {
            _propertyImageRepository = propertyImageRepository;
            _mapper = mapper;
        }

        public async Task<Result<PropertyImageDto>> Handle(GetPropertyImageQuery request, CancellationToken cancellationToken)
        {
            var propertyImage = await _propertyImageRepository.GetById(request.IdPropertyImage);
            if(propertyImage is null)
                return Result.Failure<PropertyImageDto>(PropertyImageError.NotFound);

            var dto = _mapper.Map<PropertyImageDto>(propertyImage);
            return Result.Success(dto);
        }
    }
}
