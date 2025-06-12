using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.Properties.Commands.DeleteProperty
{
    internal sealed class DeletePropertyCommandHandler : ICommandHandler<DeletePropertyCommand, Guid>
    {
        private readonly IPropertyRepository _propertyRepository;

        public DeletePropertyCommandHandler(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<Guid>> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            Property property = await _propertyRepository.GetById(request.Id);

            if(property is null)
                return Result.Failure<Guid>(PropertyError.NotFound);

            await _propertyRepository.DeleteOne(property.Id);

            return Result.Success(property.Id);
        }
    }
}
