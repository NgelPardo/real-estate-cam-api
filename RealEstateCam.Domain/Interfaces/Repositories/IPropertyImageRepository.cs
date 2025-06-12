using RealEstateCam.Domain.Entities.Properties;

namespace RealEstateCam.Domain.Interfaces.Repositories
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImage> GetById(Guid id);
        Task<PropertyImage> GetByIdProperty(Guid idProperty);
        Task<PropertyImage> InsertOne(PropertyImage propertyImage);
        Task<bool> DeleteOne(Guid id);
    }
}
