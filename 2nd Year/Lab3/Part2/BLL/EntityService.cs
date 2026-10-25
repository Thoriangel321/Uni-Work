using System;
using System.Collections.Generic;
using System.Text;
using Lab3.BLL.Models;
using Lab3.DAL;
using Lab3.DAL.Entities;
using Lab3.BLL.Exceptions;

namespace Lab3.BLL
{
    public class EntityService
    {
        private readonly EntityContext<StudentEntity> _context;

        public EntityService()
        {
            _context = new EntityContext<StudentEntity>();
        }

        public void SaveStudents(IEnumerable<StudentModel> students, string filePath, string providerType)
        {
            _context.SetProvider(providerType);

            var entities = students.Select(s => new StudentEntity
            {
                Surname = s.FullName.Split(' ')[0],
                Name = s.FullName.Split(' ').Length > 1 ? s.FullName.Split(' ')[1] : "",
                Height = s.Height,
                Weight = s.Weight,
                StudentCard = s.StudentCard,
                Passport = "N/A"
            });

            _context.SaveData(entities, filePath);
        }

        public IEnumerable<StudentModel> GetIdealWeightStudents(string filePath, string providerType)
        {
            _context.SetProvider(providerType);
            var entities = _context.LoadData(filePath);

            var models = entities.Select(e => new StudentModel
            {
                FullName = $"{e.Surname} {e.Name}",
                Height = e.Height,
                Weight = e.Weight,
                StudentCard = e.StudentCard
            }).ToList();

            // checking business logic
            if (models.Any(m => m.Weight <= 0 || m.Height <= 0))
                throw new InvalidWeightException("found student w/ incorrect data.");

            return models.Where(m => m.IsIdealWeight());
        }
    }
}
