using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.Properties.Commands.DeleteProperty
{
    public sealed record DeletePropertyCommand(Guid Id) : ICommand<Guid>;
}
