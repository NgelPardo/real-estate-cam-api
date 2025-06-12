using RealEstateCam.Domain.Entities.Properties;

namespace RealEstateCam.Domain.Interfaces.Repositories
{
    public interface IPropertyRepository
    {
        Task<Property> GetById(Guid id);
        Task<List<Property>> GetAll();
        Task<List<Property>> GetByFilters(string name, string address, decimal minPrice, decimal maxPrice);
        Task<Guid> InsertOne(Property property);
        Task<Property> UpdateOne(Property property);
        Task<Guid> DeleteOne(Guid id);
    }
}
