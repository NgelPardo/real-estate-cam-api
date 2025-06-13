namespace RealEstateCam.Application.Users.DTOs
{
    public record RegisterUserRequest(
        string nombre,
        string apellido,
        string email,
        string password);
}
