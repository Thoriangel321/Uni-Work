using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lab3.DAL.Providers
{
    public class JsonProvider<T> : IDataProvider<T>
    {
        public void Serialize(IEnumerable<T> data, string filePath)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<T> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}
