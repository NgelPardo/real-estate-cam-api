using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.Owners.Commands.CreateOwner
{
    public record CreateOwnerCommand(
        string Name,
        string Address,
        string? Photo,
        DateTime Birthday
    ) : ICommand<Guid>;
}
