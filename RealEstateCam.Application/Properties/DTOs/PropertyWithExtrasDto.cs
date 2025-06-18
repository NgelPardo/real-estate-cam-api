namespace RealEstateCam.Application.Properties.DTOs
{
    public sealed class PropertyWithExtrasDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string? CodeInternal { get; init; }
        public int Year { get; init; }
        public Guid IdOwner { get; init; }

        public string? OwnerName { get; init; }
        public string? Image { get; init; }
    }
}
