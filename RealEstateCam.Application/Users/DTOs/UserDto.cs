namespace RealEstateCam.Application.Users.DTOs
{
    public sealed class UserDto
    {
        public UserDto(Guid id, string name, string lastName, string email)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
        }
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
    }
}
