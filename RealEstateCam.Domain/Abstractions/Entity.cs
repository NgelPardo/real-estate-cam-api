namespace RealEstateCam.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity() { }

        protected Entity(Guid id) {
            
        }

        public Guid Id { get; init; }
    }
}
