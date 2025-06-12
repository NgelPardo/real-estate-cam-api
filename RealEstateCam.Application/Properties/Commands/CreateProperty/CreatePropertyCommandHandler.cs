using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Commands.CreateProperty
{
    internal sealed class CreatePropertyCommandHandler : ICommandHandler<CreatePropertyCommand, Guid>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPropertyRepository _propertyRepository;

        public CreatePropertyCommandHandler(IOwnerRepository ownerRepository, IPropertyRepository propertyRepository)
        {
            _ownerRepository = ownerRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<Guid>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetById(request.IdOwner);

            if (owner is null)
                return Result.Failure<Guid>(OwnerError.NotFound);

            var property = Property.Create(
                request.Name,
                request.Address,
                request.Price,
                request.CodeInternal,
                request.Year,
                owner.Id
            );

            var result = await _propertyRepository.InsertOne( property );

            return property.Id;
        }
    }
}
