using RealEstateCam.Application.Abstractions.Messaging;

namespace RealEstateCam.Application.Users.Commands.RegisterUser
{
    public sealed record RegisterUserCommand(
        string Nombre,
        string Apellido,
        string Email,
        string Password
    ) : ICommand<Guid>;
}
