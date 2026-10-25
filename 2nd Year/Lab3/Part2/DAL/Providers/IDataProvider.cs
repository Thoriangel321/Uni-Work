using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.DAL.Providers
{
    public interface IDataProvider<T>
    {
        void Serialize(IEnumerable<T> data, string filePath);
        IEnumerable<T> Deserialize(string filePath);
    }
}
