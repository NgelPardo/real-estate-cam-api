using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Commands.UpdateProperty
{
    internal sealed class UpdatePropertyCommandHandler : ICommandHandler<UpdatePropertyCommand, Guid>
    {
        private readonly IPropertyRepository _propertyRepository;

        public UpdatePropertyCommandHandler(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<Guid>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            Property property = await _propertyRepository.GetById(request.Id);

            if (property is null)
                return Result.Failure<Guid>(PropertyError.NotFound);

            property.Update(request.Name, request.Address, request.Price, request.CodeInternal!, request.Year, request.IdOwner);

            await _propertyRepository.UpdateOne(property);

            return property.Id;
        }
    }
}
