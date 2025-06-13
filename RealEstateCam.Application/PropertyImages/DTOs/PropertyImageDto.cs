using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RealEstateCam.Application.PropertyImages.DTOs
{
    public class PropertyImageDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("id_property")]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid IdProperty { get; set; }

        [BsonElement("file")]
        public string? File {  get; set; }

        [BsonElement("enabled")]
        public bool Enabled { get; set; }
    }
}
