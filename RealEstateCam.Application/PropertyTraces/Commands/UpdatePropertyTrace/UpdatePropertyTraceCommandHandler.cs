using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyTraces.Commands.UpdatePropertyTrace
{
    internal sealed class UpdatePropertyTraceCommandHandler : ICommandHandler<UpdatePropertyTraceCommand, Guid>
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;

        public UpdatePropertyTraceCommandHandler(IPropertyTraceRepository propertyTraceRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
        }

        public async Task<Result<Guid>> Handle(UpdatePropertyTraceCommand request, CancellationToken cancellationToken)
        {
            var propertyTrace = await _propertyTraceRepository.GetByIdAsync(request.Id);
            if(propertyTrace is null)
                return Result.Failure<Guid>(PropertyTraceError.NotFound);

            propertyTrace.Update(request.DateSale, request.Name, request.Value, request.Tax, request.IdProperty);

            await _propertyTraceRepository.UpdateAsync(propertyTrace);

            return propertyTrace.Id;
        }
    }
}
