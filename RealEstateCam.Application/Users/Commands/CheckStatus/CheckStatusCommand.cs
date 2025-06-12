using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Users.DTOs;

namespace RealEstateCam.Application.Users.Commands.CheckStatus
{
    public record CheckStatusCommand(Guid IdUser) : ICommand<LoginDto>;
}
