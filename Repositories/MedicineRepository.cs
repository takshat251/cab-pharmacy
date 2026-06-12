using CAB_Pharmacy.Models;
using CAB_Pharmacy.Data;

namespace CAB_Pharmacy.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly JsonDataStore _dataStore;

        public MedicineRepository(JsonDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<Medicine>> GetAllAsync() => await _dataStore.LoadAsync();

        public async Task<Medicine?> GetByIdAsync(Guid id)
        {
            var medicines = await _dataStore.LoadAsync();
            return medicines.FirstOrDefault(m => m.Id == id);
        }

        public async Task AddAsync(Medicine medicine)
        {
            var medicines = (await _dataStore.LoadAsync()).ToList();
            medicines.Add(medicine);
            await _dataStore.SaveAsync(medicines);
        }

        public async Task UpdateAsync(Medicine medicine)
        {
            var medicines = (await _dataStore.LoadAsync()).ToList();
            var index = medicines.FindIndex(m => m.Id == medicine.Id);
            if (index >= 0)
            {
                medicines[index] = medicine;
                await _dataStore.SaveAsync(medicines);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var medicines = (await _dataStore.LoadAsync()).ToList();
            medicines.RemoveAll(m => m.Id == id);
            await _dataStore.SaveAsync(medicines);
        }
    }
}
