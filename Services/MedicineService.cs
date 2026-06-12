using CAB_Pharmacy.Models;
using CAB_Pharmacy.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CAB_Pharmacy.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Medicine>> GetMedicinesAsync(string? search)
        {
            var medicines = await _repository.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(search))
            {
                medicines = medicines.Where(m => m.FullName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            return medicines;
        }

        public Task<Medicine?> GetMedicineAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task AddMedicineAsync(Medicine medicine)
        {
            medicine.Id = Guid.NewGuid();
            return _repository.AddAsync(medicine);
        }

        public Task UpdateMedicineAsync(Medicine medicine) => _repository.UpdateAsync(medicine);

        public Task DeleteMedicineAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
