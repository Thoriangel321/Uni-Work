using System.Collections.Generic;
using Lab5.BLL.Models;

namespace Lab5.BLL.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        void SaveAll(IEnumerable<Student> students);
    }
}