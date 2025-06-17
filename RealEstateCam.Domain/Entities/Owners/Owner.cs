using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Owners
{
    public sealed class Owner : Entity
    {
        private Owner() { }
        public Owner(
            Guid id,
            string name, 
            string address, 
            string? photo, 
            DateTime birthday) : base(id)
        {
            Name = name;
            Address = address;
            Photo = photo;
            Birthday = birthday;
        }
        public string? Name { get; private set; }
        public string? Address { get; private set; }
        public string? Photo {  get; private set; }
        public DateTime Birthday { get; private set; }

        public static Owner Create(
            string name,
            string address,
            string? photo,
            DateTime birthday
        )
        {
            return new Owner(Guid.NewGuid(), name, address, photo, birthday);
        }
    }
}
