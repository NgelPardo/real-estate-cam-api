using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.Properties.CreateProperty
{
    public record CreatePropertyCommand(
        string Name,
        string Address,
        decimal Price,
        string CodeInternal,
        int Year,
        Guid IdOwner
    ) : ICommand<Guid>; 
}
