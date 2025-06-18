using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Queries.GetAllProperties
{
    internal sealed class GetAllPropertiesQueryHandler : IQueryHandler<GetAllPropertiesQuery, IReadOnlyList<PropertyWithExtrasDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPropertyImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetAllPropertiesQueryHandler(
            IPropertyRepository propertyRepository, 
            IOwnerRepository ownerRepository,
            IPropertyImageRepository imageRepository, 
            IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<PropertyWithExtrasDto>>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAll();
            var owners = await _ownerRepository.GetAll();
            var images = await _imageRepository.GetAll();

            var propertyDtos = properties.Select(prop =>
            {
                var owner = owners.FirstOrDefault(o => o.Id == prop.IdOwner);
                var image = images.FirstOrDefault(img => img.IdProperty == prop.Id && img.Enabled);

                return new PropertyWithExtrasDto
                {
                    Id = prop.Id,
                    Name = prop.Name,
                    Address = prop.Address,
                    Price = prop.Price,
                    CodeInternal = prop.CodeInternal,
                    Year = prop.Year,
                    IdOwner = prop.IdOwner,
                    OwnerName = owner?.Name ?? "Sin propietario",
                    ImageUrl = image?.File ?? string.Empty
                };
            }).ToList();

            return Result.Success<IReadOnlyList<PropertyWithExtrasDto>>(propertyDtos);
        }
    }
}
