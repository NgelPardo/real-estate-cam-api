namespace RealEstateCam.Application.Properties.DTOs
{
    public sealed class PropertyDto
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string? CodeInternal { get; private set; }
        public int Year { get; private set; }
        public Guid IdOwner { get; private set; }
    }
}
