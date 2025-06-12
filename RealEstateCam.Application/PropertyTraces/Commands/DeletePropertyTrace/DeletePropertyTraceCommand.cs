using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.PropertyTraces.Commands.DeletePropertyTrace
{
    public sealed record DeletePropertyTraceCommand(Guid Id) : ICommand<Guid>;
}
