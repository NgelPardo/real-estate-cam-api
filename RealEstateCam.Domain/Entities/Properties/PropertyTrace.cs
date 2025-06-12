using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Properties
{
    public sealed class PropertyTrace : Entity
    {
        private PropertyTrace() { }
        public PropertyTrace(
            Guid id,
            DateTime dateSale, 
            string name, 
            decimal value, 
            decimal tax, 
            Guid idProperty) : base(id)
        {
            DateSale = dateSale;
            Name = name;
            Value = value;
            Tax = tax;
            IdProperty = idProperty;
        }        
        public DateTime DateSale { get; private set; }
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public decimal Tax { get; private set; }
        public Guid IdProperty { get; private set; }
        
        public static PropertyTrace Create(
            DateTime dateSale,
            string name,
            decimal value,
            decimal tax,
            Guid idProperty
        )
        {
            return new PropertyTrace(Guid.NewGuid(), dateSale, name, value, tax, idProperty);
        }

        public void Update(
            DateTime dateSale,
            string name,
            decimal value,
            decimal tax,
            Guid idProperty
        )
        {
            DateSale = dateSale;
            Name = name;
            Value = value;
            Tax = tax;
            IdProperty = idProperty;
        }
    }
}
