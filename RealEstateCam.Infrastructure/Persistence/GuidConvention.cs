using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace RealEstateCam.Infrastructure.Persistence
{
    public class GuidConvention : IMemberMapConvention
    {
        public string Name => nameof(GuidConvention);

        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberType == typeof(Guid))
            {
                memberMap.SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
            }
        }
    }
}
