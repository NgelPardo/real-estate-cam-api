namespace RealEstateCam.Application.Properties.DTOs
{
    public sealed record PropertyRequest
    (
        string name,
        string address,
        decimal price,
        string codeInternal,
        int year,
        Guid idOwner
    );
}
