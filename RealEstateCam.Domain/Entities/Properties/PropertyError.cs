using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Properties
{
    public static class PropertyError
    {
        public static Error NotFound = new Error(
            "Property.Found",
            "The property with the specified id was not found"
        );
    }
}
