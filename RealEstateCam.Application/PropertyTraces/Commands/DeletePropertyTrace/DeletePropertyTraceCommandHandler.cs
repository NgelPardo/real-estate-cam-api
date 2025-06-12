using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyTraces.Commands.DeletePropertyTrace
{
    internal sealed class DeletePropertyTraceCommandHandler : ICommandHandler<DeletePropertyTraceCommand, Guid>
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;

        public DeletePropertyTraceCommandHandler(IPropertyTraceRepository propertyTraceRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
        }

        public async Task<Result<Guid>> Handle(DeletePropertyTraceCommand request, CancellationToken cancellationToken)
        {
            var propertyTrace = await _propertyTraceRepository.GetByIdAsync(request.Id);
            if(propertyTrace is null)
                return Result.Failure<Guid>(PropertyTraceError.NotFound);

            await _propertyTraceRepository.DeleteAsync(request.Id);

            return Result.Success(propertyTrace.Id);
        }
    }
}
