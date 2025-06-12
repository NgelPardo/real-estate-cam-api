using RealEstateCam.Application.Abstractions.Messaging;
using RealEstateCam.Application.Users.DTOs;

namespace RealEstateCam.Application.Users.Queries.GetUser
{
    public sealed record GetUserQuery(Guid IdUser) : IQuery<UserDto>
    {

    }
}
