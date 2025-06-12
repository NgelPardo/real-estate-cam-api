using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Abstractions;
using RealEstateCam.Domain.Entities.Properties;
using RealEstateCam.Domain.Interfaces.Repositories;

namespace RealEstateCam.Application.PropertyTraces.Commands.CreatePropertyTrace
{
    internal sealed class CreatePropertyTraceCommandHandler : ICommandHandler<CreatePropertyTraceCommand, Guid>
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        private readonly IPropertyRepository _propertyRepository;

        public CreatePropertyTraceCommandHandler(IPropertyTraceRepository propertyTraceRepository, IPropertyRepository propertyRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
            _propertyRepository = propertyRepository;
        }

        public async Task<Result<Guid>> Handle(CreatePropertyTraceCommand request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetById(request.IdProperty);
            if(property is null)
                return Result.Failure<Guid>(PropertyError.NotFound);

            var propertyTrace = PropertyTrace.Create(request.DateSale, request.Name, request.Value, request.Tax, property.Id);

            await _propertyTraceRepository.AddAsync(propertyTrace);

            return propertyTrace.Id;
        }
    }
}
