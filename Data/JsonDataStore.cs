using CAB_Pharmacy.Models;
using System.Text.Json;

namespace CAB_Pharmacy.Data
{
    public class JsonDataStore
    {
        private readonly string _filePath = "medicines.json";

        public async Task<IEnumerable<Medicine>> LoadAsync()
        {
            if (!File.Exists(_filePath)) return new List<Medicine>();
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Medicine>>(json) ?? new List<Medicine>();
        }

        public async Task SaveAsync(IEnumerable<Medicine> medicines)
        {
            var json = JsonSerializer.Serialize(medicines, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}