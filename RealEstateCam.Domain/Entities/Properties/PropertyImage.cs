using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Properties
{
    public sealed class PropertyImage : Entity
    {
        private PropertyImage() { }
        public PropertyImage(Guid id, Guid idProperty, string file, bool enabled, DateTime createdAt) : base(id)
        {
            IdProperty = idProperty;
            File = file;
            Enabled = enabled;
            CreatedAt = createdAt;
        }
        public Guid IdProperty { get; private set; }
        public string? File {  get; private set; }
        public bool Enabled { get; private set; }
        public DateTime CreatedAt { get; set; }

        public static PropertyImage Create(
            Guid idProperty, 
            string file, 
            bool enabled
        )
        {
            return new PropertyImage(Guid.NewGuid(), idProperty, file, enabled, DateTime.UtcNow);
        }
    }
}
