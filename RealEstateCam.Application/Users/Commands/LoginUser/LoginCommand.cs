using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Users.DTOs;

namespace RealEstateCam.Application.Users.Commands.LoginUser
{
    public record LoginCommand(string Email, string Password) : ICommand<LoginDto>;
}
