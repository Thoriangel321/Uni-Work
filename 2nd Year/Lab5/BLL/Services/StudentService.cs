using System;
using System.Collections.Generic;
using System.Linq;
using Lab5.BLL.Interfaces;
using Lab5.BLL.Models;

namespace Lab5.BLL.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public event Action<Student> IdealWeightReached;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void ValidateStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName))
                throw new ArgumentException("Name and Last Name are required");

            if (student.Height <= 110 || student.Weight <= 0)
                throw new ArgumentException("invalid data for weight and height");

            if (string.IsNullOrWhiteSpace(student.StudentCard) || string.IsNullOrWhiteSpace(student.Passport))
                throw new ArgumentException("Doc data is required");
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            var list = students.ToList();
            foreach (var student in list)
            {
                ValidateStudent(student);
            }
            _repository.SaveAll(list);
        }

        public int CountIdealWeightStudents()
        {
            var students = _repository.GetAll();
            int count = 0;

            foreach (var student in students)
            {
                ValidateStudent(student);
                if (IsIdealWeight(student))
                {
                    count++;
                }
            }

            return count;
        }

        public void GainWeight(Student student, double amount)
        {
            ValidateStudent(student);
            if (amount <= 0)
                throw new ArgumentException("weight < 0");

            student.Weight += amount;
            CheckAndNotifyIdealWeight(student);
        }

        public void LoseWeight(Student student, double amount)
        {
            ValidateStudent(student);
            if (amount <= 0 || student.Weight - amount <= 0)
                throw new ArgumentException("Invalid weight change");

            student.Weight -= amount;
            CheckAndNotifyIdealWeight(student);
        }

        private bool IsIdealWeight(Student student)
        {
            return Math.Abs((student.Height - 110) - student.Weight) < 0.001;
        }

        private void CheckAndNotifyIdealWeight(Student student)
        {
            if (IsIdealWeight(student))
            {
                IdealWeightReached?.Invoke(student);
            }
        }
    }
}