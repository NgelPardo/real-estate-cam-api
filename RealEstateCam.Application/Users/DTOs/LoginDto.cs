namespace RealEstateCam.Application.Users.DTOs
{
    public sealed class LoginDto
    {
        public LoginDto(UserDto user, string? token)
        {
            User = user;
            Token = token;
        }

        public UserDto User { get; set; }
        public string? Token { get; set; }
    }
}
