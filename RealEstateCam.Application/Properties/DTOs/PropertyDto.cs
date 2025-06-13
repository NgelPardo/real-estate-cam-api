using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstateCam.Application.Properties.DTOs
{
    public class PropertyDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("code_internal")]
        public string? CodeInternal { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("id_owner")]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid IdOwner { get; set; }
    }
}
