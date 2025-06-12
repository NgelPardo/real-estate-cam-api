using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Properties
{
    public static class PropertyTraceError
    {
        public static Error NotFound = new Error(
            "PropertyTrace.Found",
            "The property trace with the specified id was not found"
        );
    }
}
