using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

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

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; init; }

        [BsonElement("name")]
        public string? Name { get; init; }

        [BsonElement("last_name")]
        public string? LastName { get; init; }

        [BsonElement("email")]
        public string? Email { get; init; }
    }
}
