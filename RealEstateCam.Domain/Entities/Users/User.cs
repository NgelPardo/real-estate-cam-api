using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Users
{
    public sealed class User : Entity
    {
        private User() { }
        private User(
            Guid id,
            string name,
            string lastName,
            string email,
            string passwordHash
            ) : base(id)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }

        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PasswordHash { get; private set; }
        public static User Create(
            string name,
            string lastName,
            string email,
            string passwordHash
        )
        {
            var user = new User(
                Guid.NewGuid(),
                name,
                lastName,
                email,
                passwordHash
            );
            return user;
        }
    }
}
