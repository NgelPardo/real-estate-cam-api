using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.Owners.Commands.DeleteOwner
{
    public sealed record DeleteOwnerCommand(Guid Id) : ICommand<Guid>;
    
}
