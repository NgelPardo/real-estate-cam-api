using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Queries.GetProperty
{
    internal sealed class GetQueryHandler : IQueryHandler<GetPropertyQuery, PropertyWithExtrasDto>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IMapper _mapper;

        public GetQueryHandler(IPropertyRepository propertyRepository, IPropertyImageRepository propertyImageRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _propertyImageRepository = propertyImageRepository;
            _mapper = mapper;
        }

        public async Task<Result<PropertyWithExtrasDto>> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetById(request.IdProperty);
            var image = await _propertyImageRepository.GetByIdProperty(property.Id);

            if(property is null)
                return Result.Failure<PropertyWithExtrasDto>(PropertyError.NotFound);


            var propertyDto = new PropertyWithExtrasDto
            {
                Id = property.Id,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                CodeInternal = property.CodeInternal,
                Year = property.Year,
                IdOwner = property.IdOwner,
                Image = image?.File ?? string.Empty
            };

            return Result.Success(propertyDto);
        }
    }
}
