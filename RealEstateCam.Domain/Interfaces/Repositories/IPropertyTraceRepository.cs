using RealEstateCam.Domain.Entities.Properties;

namespace RealEstateCam.Domain.Interfaces.Repositories
{
    public interface IPropertyTraceRepository
    {
        Task<List<PropertyTrace>> GetByPropertyIdAsync(string propertyId);
        Task<PropertyTrace?> GetByIdAsync(string id);
        Task<PropertyTrace> AddAsync(PropertyTrace trace);
        Task<PropertyTrace> UpdateAsync(PropertyTrace trace);
        Task<bool> DeleteAsync(string id);
    }
}
