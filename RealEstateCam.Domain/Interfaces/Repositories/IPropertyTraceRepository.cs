using RealEstateCam.Domain.Entities.Properties;

namespace RealEstateCam.Domain.Interfaces.Repositories
{
    public interface IPropertyTraceRepository
    {
        Task<List<PropertyTrace>> GetByPropertyIdAsync(Guid propertyId);
        Task<PropertyTrace?> GetByIdAsync(Guid id);
        Task<PropertyTrace> AddAsync(PropertyTrace trace);
        Task<PropertyTrace> UpdateAsync(PropertyTrace trace);
        Task<bool> DeleteAsync(string id);
    }
}
