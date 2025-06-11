using RealEstateCam.Domain.Entities.Owners;

namespace RealEstateCam.Domain.Interfaces.Repositories
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAll();
        Task<Owner> GetById(string name, string address, decimal minPrice, decimal maxPrice);
        Task<Owner> InsertOne(Owner owner);
        Task<Owner> UpdateOne(Owner owner);
        Task<bool> DeleteOne(Guid id);
    }
}
