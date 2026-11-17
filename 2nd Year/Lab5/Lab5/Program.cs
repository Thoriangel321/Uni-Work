using System;
using System.Collections.Generic;
using System.Text;
using Lab5.BLL.Entities;
using Lab5.BLL.Interfaces;
using Lab5.BLL.Models;
using Lab5.BLL.Services;
using Lab5.DAL.Repositories;

namespace Lab5.PL
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            IStudentRepository repository = new JsonStudentRepository("students.json");
            StudentService service = new StudentService(repository);

            service.IdealWeightReached += student =>
                Console.WriteLine($"Notification: {student.FirstName} {student.LastName} got to the perfect weight ({student.Weight} kg)!");

            var students = new List<Student>
            {
                new Student { LastName = "Kovalenko", FirstName = "Bogdan", Height = 180, Weight = 70, StudentCard = "КВ101", Passport = "АА123456" },
                new Student { LastName = "Shevchenko", FirstName = "Anna", Height = 165, Weight = 50, StudentCard = "КВ102", Passport = "ВВ654321" },
                new Student { LastName = "Darkholme", FirstName = "Van", Height = 185, Weight = 80, StudentCard = "КВ103", Passport = "СС112233" }
            };

            service.SaveStudents(students);

            Console.WriteLine($"Students w/ perfect weight: {service.CountIdealWeightStudents()}");

            service.GainWeight(students[1], 5);
            service.LoseWeight(students[2], 5);

            Console.WriteLine(students[0].RideBicycle());

            var librarian = new Librarian { Name = "Olena" };
            var developer = new SoftwareDeveloper { Name = "Max" };

            Console.WriteLine(librarian.StudyOnline(true));
            Console.WriteLine(developer.StudyOnline(false));
            Console.WriteLine(developer.RideBicycle());
        }
    }
}