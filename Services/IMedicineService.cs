using CAB_Pharmacy.Models;

namespace CAB_Pharmacy.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetMedicinesAsync(string? search);
        Task<Medicine?> GetMedicineAsync(Guid id);
        Task AddMedicineAsync(Medicine medicine);
        Task UpdateMedicineAsync(Medicine medicine);
        Task DeleteMedicineAsync(Guid id);
    }
}
