using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyImages.Commands.DeletePropertyImage
{
    internal sealed class DeletePropertyImageCommandHandler : ICommandHandler<DeletePropertyImageCommand, Guid>
    {
        private readonly IPropertyImageRepository _propertyImageRepository;

        public DeletePropertyImageCommandHandler(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }

        public async Task<Result<Guid>> Handle(DeletePropertyImageCommand request, CancellationToken cancellationToken)
        {
            PropertyImage propertyImage = await _propertyImageRepository.GetByIdProperty(request.Id);

            if (propertyImage is null)
                return Result.Failure<Guid>(PropertyImageError.NotFound);

            await _propertyImageRepository.DeleteOne(propertyImage.Id);

            return Result.Success(propertyImage.Id);
        }
    }
}
