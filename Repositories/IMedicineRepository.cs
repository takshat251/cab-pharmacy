using CAB_Pharmacy.Models;

namespace CAB_Pharmacy.Repositories
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task<Medicine?> GetByIdAsync(Guid id);
        Task AddAsync(Medicine medicine);
        Task UpdateAsync(Medicine medicine);
        Task DeleteAsync(Guid id);
    }
}