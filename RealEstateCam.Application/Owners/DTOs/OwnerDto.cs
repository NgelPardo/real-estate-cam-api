using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RealEstateCam.Application.Owners.DTOs
{
    public class OwnerDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("photo")]
        public string? Photo { get; set; }
        
        [BsonElement("birthday")]
        public DateTime Birthday { get; set; }
    }
}
