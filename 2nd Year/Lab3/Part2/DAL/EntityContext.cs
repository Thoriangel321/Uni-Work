using Lab3.DAL.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DAL
{
    public class EntityContext<T>
    {
        private IDataProvider<T> _provider;

        public void SetProvider(string type)
        {
            _provider = type.ToLower() switch
            {
                "json" => new JsonProvider<T>(),
                "xml" => new XmlProvider<T>(),
                "binary" => new BinaryProvider<T>(), 
                _ => throw new ArgumentException("unknown provider type")
            };
        }

        public void SaveData(IEnumerable<T> data, string filePath) => _provider.Serialize(data, filePath);
        public IEnumerable<T> LoadData(string filePath) => _provider.Deserialize(filePath);
    }
}
