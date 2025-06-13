using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RealEstateCam.Application.PropertyTraces.DTOs
{
    public class PropertyTraceDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("date_sale")]
        public DateTime DateSale { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("value")]
        public decimal Value { get; set; }

        [BsonElement("tax")]
        public decimal Tax { get; set; }

        [BsonElement("id_property")]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid IdProperty { get; set; }
    }
}
