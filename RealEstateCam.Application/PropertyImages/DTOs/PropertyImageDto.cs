namespace RealEstateCam.Application.PropertyImages.DTOs
{
    public sealed class PropertyImageDto
    {
        public Guid Id { get; set; }
        public Guid IdProperty { get; set; }
        public string? File {  get; set; }
        public bool Enabled { get; set; }
    }
}
