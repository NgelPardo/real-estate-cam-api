namespace RealEstateCam.Application.Owners.DTOs
{
    public sealed record OwnerRequest
    (
        string name,
        string address,
        string photo,
        DateTime birthday
    );
}
