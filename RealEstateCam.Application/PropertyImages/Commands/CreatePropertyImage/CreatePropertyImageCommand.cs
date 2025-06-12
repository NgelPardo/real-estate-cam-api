using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Domain.Entities.Properties;

namespace RealEstateCam.Application.PropertyImages.Commands.CreatePropertyImage
{
    public record CreatePropertyImageCommand(
        Guid IdProperty,
        string File,
        bool Enabled
        ) : ICommand<Guid>;
}
