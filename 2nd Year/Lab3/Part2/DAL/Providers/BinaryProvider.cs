using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab3.DAL.Providers
{
    public class BinaryProvider<T> : IDataProvider<T>
    {
        public void Serialize(IEnumerable<T> data, string filePath)
        {
#pragma warning disable SYSLIB0011 //disable warning about obsolete thing
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, new List<T>(data));
            }
#pragma warning restore SYSLIB0011
        }

        public IEnumerable<T> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
#pragma warning disable SYSLIB0011
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<T>)formatter.Deserialize(fs);
            }
#pragma warning restore SYSLIB0011
        }
    }
}
