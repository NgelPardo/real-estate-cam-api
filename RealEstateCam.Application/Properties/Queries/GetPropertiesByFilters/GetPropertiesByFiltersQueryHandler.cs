using AutoMapper;
using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Queries.GetPropertiesByFilters
{
    internal sealed class GetPropertiesByFiltersQueryHandler : IQueryHandler<GetPropertiesByFiltersQuery, IReadOnlyList<PropertyWithExtrasDto>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IMapper _mapper;

        public GetPropertiesByFiltersQueryHandler(IPropertyRepository propertyRepository, IPropertyImageRepository propertyImageRepository, IMapper mapper)
        {
            _propertyImageRepository = propertyImageRepository;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<PropertyWithExtrasDto>>> Handle(GetPropertiesByFiltersQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetByFilters(request.Name, request.Address, request.MinPrice, request.MaxPrice);
            var images = await _propertyImageRepository.GetAll();

            var latestImagesByProperty = images
                .Where(img => img.Enabled)
                .GroupBy(img => img.IdProperty)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(img => img.CreatedAt).First()
                );

            var propertyDtos = properties.Select(prop =>
            {
                var image = latestImagesByProperty.TryGetValue(prop.Id, out var img) ? img : null;

                return new PropertyWithExtrasDto
                {
                    Id = prop.Id,
                    Name = prop.Name,
                    Address = prop.Address,
                    Price = prop.Price,
                    CodeInternal = prop.CodeInternal,
                    Year = prop.Year,
                    IdOwner = prop.IdOwner,
                    OwnerName = "Propietario",
                    Image = image?.File ?? string.Empty
                };
            }).ToList();

            return Result.Success<IReadOnlyList<PropertyWithExtrasDto>>(propertyDtos);
        }
    }
}
