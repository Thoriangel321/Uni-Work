using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Domain.Core.Services
{
    public class JsonFileService<T>
    {
        private readonly string _filePath;

        public JsonFileService(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(List<T> data)
        {
            string? directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_filePath, json);
        }

        public List<T> Load()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}