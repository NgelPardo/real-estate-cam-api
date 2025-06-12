using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.PropertyTraces.Commands.CreatePropertyTrace
{
    public record CreatePropertyTraceCommand(
        DateTime DateSale,
        string Name,
        decimal Value,
        decimal Tax,
        Guid IdProperty
        ) : ICommand<Guid>;
}
