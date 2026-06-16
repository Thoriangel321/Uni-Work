using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Practics
{
    internal class FileStorageManager
    {
        public void Serialize(EmployeeList list, string filePath)
        {
            Employee[] arr = new Employee[list.Length];

            if (list.Length > 0)
            {
                Employee current = list.GetFirst();
                for (int i = 0; i < list.Length; i++)
                {
                    arr[i] = current;
                    current = list.GetNext();
                }
            }

            File.WriteAllText(filePath, JsonSerializer.Serialize(arr));
        }

        public EmployeeList Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found.");

            Employee[] arr = JsonSerializer.Deserialize<Employee[]>(File.ReadAllText(filePath));
            EmployeeList newList = new EmployeeList();

            if (arr != null)
            {
                foreach (var emp in arr)
                {
                    newList.AddLast(emp);
                }
            }

            return newList;
        }
    }
}
