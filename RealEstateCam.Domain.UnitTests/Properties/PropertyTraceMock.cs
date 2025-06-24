namespace RealEstateCam.Domain.UnitTests.Properties
{
    internal class PropertyTraceMock
    {
        public static readonly DateTime DateSale = new DateTime(2023, 1, 1);
        public static readonly string Name = "Test Property Trace";
        public static readonly decimal Value = 300000m;
        public static readonly decimal Tax = 15000m;
        public static readonly Guid IdProperty = Guid.NewGuid();
    }
}