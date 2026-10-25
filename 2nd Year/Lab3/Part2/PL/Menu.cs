using System;
using System.Collections.Generic;
using System.Text;
using Lab3.BLL;
using Lab3.BLL.Models;

namespace Lab3.PL
{
    public class Menu
    {
        private readonly EntityService _service;

        public Menu()
        {
            _service = new EntityService();
        }

        public void MainMenu()
        {
            try
            {
                Console.WriteLine("Enter Filetype (json/xml):");
                string fileType = Console.ReadLine();
                string filePath = $"data.{fileType}";

                var newStudents = new List<StudentModel>
                {
                    new StudentModel { FullName = "Van Darkholme", Height = 180, Weight = 70, StudentCard = "KB123" }, // perf
                    new StudentModel { FullName = "Walter White", Height = 165, Weight = 50, StudentCard = "KB124" },
                    new StudentModel { FullName = "Petryk", Height = 190, Weight = 80, StudentCard = "KB125" }  // perf
                };

                _service.SaveStudents(newStudents, filePath, fileType);
                Console.WriteLine("data saved.\n");

                Console.WriteLine("Analyzing...");
                var idealStudents = _service.GetIdealWeightStudents(filePath, fileType);

                int count = 0;
                foreach (var student in idealStudents)
                {
                    Console.WriteLine($"- {student.FullName} (Height: {student.Height}, Weight: {student.Weight})");
                    count++;
                }
                Console.WriteLine($"\nStudents w/ pefect weight: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error, bro: {ex.Message}");
            }
        }
    }
}
