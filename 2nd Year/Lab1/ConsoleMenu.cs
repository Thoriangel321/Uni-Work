using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using Objects;
using System.IO.Enumeration;

namespace ConsoleIO
{
    enum Classes
    {
        Student = 0,
        Librarian = 1,
        SoftwareDeveloper = 2
    }

    internal class ConsoleMenu
    {
        public static FileManagment fmanager = new FileManagment();
        public static InputValidation validator = new InputValidation();
        public static string filename;

        static void Main(string[] args)
        {
            Console.Write("Enter file name: ");
            filename = Console.ReadLine();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nSelect Action: ");
                Console.WriteLine("H - Help");
                Console.WriteLine("A - Add entity");
                Console.WriteLine("L - List file contents");
                Console.WriteLine("R - Reset file");
                Console.WriteLine("S - Search by last name");
                Console.WriteLine("Q - Quit");

                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.A:
                        AddEntityMenu();
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine(fmanager.listFile(filename));
                        break;
                    case ConsoleKey.R:
                        fmanager.resetFile(filename);
                        Console.WriteLine("File reset.");
                        break;
                    case ConsoleKey.S:
                        Console.Write("Enter a last name: ");
                        string lastname = Console.ReadLine();
                        string searchResult = fmanager.searchByLastName(filename, lastname);
                        Console.WriteLine(string.IsNullOrEmpty(searchResult) ? "Not found." : searchResult);
                        break;
                    case ConsoleKey.Q:
                        isRunning = false;
                        break;
                }
            }
        }

        static void AddEntityMenu()
        {
            Console.WriteLine("Available Entities: ");
            foreach (Classes type in Enum.GetValues(typeof(Classes)))
            {
                Console.WriteLine($"{(int)type} - {type}");
            }

            ConsoleKeyInfo selection = Console.ReadKey(true);
            Console.WriteLine();

            switch (selection.Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Student student = new Student();
                    student.firstName = GetValidInput("First Name: ", validator.isValidName);
                    student.lastName = GetValidInput("Last Name: ", validator.isValidName);
                    student.studID = GetValidInput("Student ID: ", validator.isValidStudID);

                    Console.Write("Height: ");
                    int.TryParse(Console.ReadLine(), out int height);
                    student.height = height;

                    Console.Write("Weight: ");
                    int.TryParse(Console.ReadLine(), out int weight);
                    student.weight = weight;

                    student.passID = GetValidInput("Pass ID: ", validator.isValidStudID);
                    student.Study();

                    fmanager.appendToFile(filename, student);
                    break;

                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Librarian librarian = new Librarian();
                    librarian.firstName = GetValidInput("First Name: ", validator.isValidName);
                    librarian.lastName = GetValidInput("Last Name: ", validator.isValidName);
                    librarian.Reading();

                    fmanager.appendToFile(filename, librarian);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    SoftwareDeveloper dev = new SoftwareDeveloper();
                    dev.firstName = GetValidInput("First Name: ", validator.isValidName);
                    dev.lastName = GetValidInput("Last Name: ", validator.isValidName);
                    dev.Develop();

                    fmanager.appendToFile(filename, dev);
                    break;
            }
        }

        static string GetValidInput(string prompt, Func<string, bool> validationMethod)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!validationMethod(input))
                {
                    Console.WriteLine("Invalid input format. Try again.");
                }
            } while (!validationMethod(input));

            return input;
        }
    }

}
