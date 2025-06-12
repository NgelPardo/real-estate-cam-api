using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.PropertyTraces.Commands.UpdatePropertyTrace
{
    public record UpdatePropertyTraceCommand(
        Guid Id,
        DateTime DateSale,
        string Name,
        decimal Value,
        decimal Tax,
        Guid IdProperty
    ) : ICommand<Guid>;
}
