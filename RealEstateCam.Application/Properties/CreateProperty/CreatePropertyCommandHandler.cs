using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Application.Properties.CreateProperty
{
    internal sealed class CreatePropertyCommandHandler : ICommandHandler<CreatePropertyCommand, Guid>
    {
        public Task<Result<Guid>> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
