using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyImages.Commands.CreatePropertyImage
{
    internal sealed class CreatePropertyImageCommandHandler : ICommandHandler<CreatePropertyImageCommand, Guid>
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IPropertyRepository _propertyRepository;

        public CreatePropertyImageCommandHandler(IPropertyImageRepository propertyImageRepository, IPropertyRepository propertyRepository)
        {
            _propertyImageRepository = propertyImageRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<Guid>> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetById(request.IdProperty);
            
            if(property is null)
                return Result.Failure<Guid>(PropertyError.NotFound);

            var propertyImage = PropertyImage.Create(property.Id, request.File, request.Enabled);

            await _propertyImageRepository.InsertOne(propertyImage);

            return propertyImage.Id;
        }
    }
}
