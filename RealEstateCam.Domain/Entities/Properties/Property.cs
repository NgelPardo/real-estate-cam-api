using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Properties
{
    public sealed class Property : Entity
    {
        private Property() { }
        private Property(
            Guid id,
            string name, 
            string address, 
            decimal price, 
            string codeInternal, 
            int year, 
            Guid idOwner) : base(id)
        {
            Name = name;
            Address = address;
            Price = price;
            CodeInternal = codeInternal;
            Year = year;
            IdOwner = idOwner;
        }
        public string Name { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string? CodeInternal { get; private set; }
        public int Year { get; private set; }
        public Guid IdOwner { get; private set; }

        public static Property Create(
            string name,
            string address,
            decimal price,
            string codeInternal,
            int year,
            Guid idOwner
        )
        {
            return new Property(Guid.NewGuid(), name, address, price, codeInternal, year, idOwner);
        }

        public void Update(
            string name,
            string address,
            decimal price,
            string codeInternal,
            int year,
            Guid idOwner
        )
        {
            Name = name;
            Address = address; 
            Price = price;
            CodeInternal = codeInternal;
            Year = year;
            IdOwner = idOwner;
        }
    }
}
