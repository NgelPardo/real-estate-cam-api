namespace RealEstateCam.Domain.UnitTests.Properties
{ 
    internal class PropertyMock
    {
        public static readonly string Name = "Test Property";
        public static readonly string Address = "123 Test St";
        public static readonly decimal Price = 250000m;
        public static readonly string CodeInternal = "TP-001";
        public static readonly int Year = 2023;
        public static readonly Guid IdOwner = Guid.NewGuid();
    }
}