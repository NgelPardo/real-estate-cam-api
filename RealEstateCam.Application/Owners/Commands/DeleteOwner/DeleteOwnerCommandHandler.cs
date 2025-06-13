using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Owners;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Owners.Commands.DeleteOwner
{
    internal sealed class DeleteOwnerCommandHandler : ICommandHandler<DeleteOwnerCommand, Guid>
    {
        private readonly IOwnerRepository _ownerRepository;

        public DeleteOwnerCommandHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<Result<Guid>> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetById(request.Id);

            if(owner is null)
                return Result.Failure<Guid>(OwnerError.NotFound);

            await _ownerRepository.DeleteOne(owner.Id);

            return Result.Success(owner.Id);
        }
    }
}
