using RealEstateCam.Domain.Abstractions;

namespace RealEstateCam.Domain.Entities.Owners
{
    public static class OwnerError
    {
        public static Error NotFound = new Error(
            "Owner.Found",
            "Owner not found"
        );
    }
}
