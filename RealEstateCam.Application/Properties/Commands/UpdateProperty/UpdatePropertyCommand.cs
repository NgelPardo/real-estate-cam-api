using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.Properties.Commands.UpdateProperty
{
    public record UpdatePropertyCommand(
        Guid Id,
        string Name,
        string Address,
        decimal Price,
        string? CodeInternal,
        int Year,
        Guid IdOwner    
    ) : ICommand<Guid>;
}
