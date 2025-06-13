using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Owners.Commands.CreateOwner
{
    internal sealed class CreateOwnerCommandHandler : ICommandHandler<CreateOwnerCommand, Guid>
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Result<Guid>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = Owner.Create(request.Name, request.Address, request.Photo, request.Birthday);

            await _ownerRepository.InsertOne(owner);

            return owner.Id;
        }
    }
}
