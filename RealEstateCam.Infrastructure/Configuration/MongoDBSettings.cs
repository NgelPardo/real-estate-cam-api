namespace RealEstateCam.Infrastructure.Configuration
{
    public class MongoDBSettings
    {
        public const string BindName = "MongoDB";

        public string MONGO_URI { get; set; } = string.Empty;
        public string DATABASE_NAME { get; set; } = string.Empty;
    }
}
