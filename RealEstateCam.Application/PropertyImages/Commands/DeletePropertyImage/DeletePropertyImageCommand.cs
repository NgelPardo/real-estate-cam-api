using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.PropertyImages.Commands.DeletePropertyImage
{
    public sealed record DeletePropertyImageCommand(Guid Id) : ICommand<Guid>;
}
