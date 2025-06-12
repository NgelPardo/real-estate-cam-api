using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Properties
{
    public static class PropertyImageError
    {
        public static Error NotFound = new Error(
            "PropertyImage.Found",
            "The property image with the specified id was not found"
        );
    }
}
