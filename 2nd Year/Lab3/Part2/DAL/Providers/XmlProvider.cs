using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Lab3.DAL.Providers
{
    public class XmlProvider<T> : IDataProvider<T>
    {
        public void Serialize(IEnumerable<T> data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, new List<T>(data));
            }
        }

        public IEnumerable<T> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<T>)serializer.Deserialize(fs);
            }
        }
    }
}
