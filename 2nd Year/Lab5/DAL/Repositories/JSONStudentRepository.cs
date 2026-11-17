using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Lab5.BLL.Interfaces;
using Lab5.BLL.Models;

namespace Lab5.DAL.Repositories
{
    public class JsonStudentRepository : IStudentRepository
    {
        private readonly string _filePath;

        public JsonStudentRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Student> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        public void SaveAll(IEnumerable<Student> students)
        {
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(_filePath, json);
        }
    }
}