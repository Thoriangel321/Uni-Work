namespace Practics
{
    internal class Program
    {

        static EmployeeList list = new EmployeeList();
        static FileStorageManager storage = new FileStorageManager();
        const string FilePath = "employees.json";
        static void Main(string[] args)
        {
                while (true)
                {
                    Console.WriteLine("\n--- Menu ---");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Remove First Employee");
                    Console.WriteLine("3. Change Employee by Index");
                    Console.WriteLine("4. Search (Salary < Avg & Remote)");
                    Console.WriteLine("5. Serialize to JSON");
                    Console.WriteLine("6. Deserialize from JSON");
                    Console.WriteLine("7. Exit");
                    Console.Write("Choice: ");

                    try
                    {
                        switch (Console.ReadLine())
                        {
                            case "1": AddEmployee(); PrintTable(list); break;
                            case "2": list.RemoveFirst(); PrintTable(list); break;
                            case "3": UpdateEmployee(); PrintTable(list); break;
                            case "4": PrintTable(list.Search()); break;
                            case "5":
                                storage.Serialize(list, FilePath);
                                Console.WriteLine("Saved.");
                                break;
                            case "6":
                                list = storage.Deserialize(FilePath);
                                PrintTable(list);
                                break;
                        case "7": return;
                            default: Console.WriteLine("Invalid choice."); break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            

            static void AddEmployee()
            {
                Console.Write("Department (0:HR, 1:IT, 2:Finance, 3:Marketing): ");
                if (!Enum.TryParse(Console.ReadLine(), out Department dept)) throw new Exception("Invalid Department");

                Console.Write("Salary: ");
                if (!double.TryParse(Console.ReadLine(), out double salary)) throw new Exception("Invalid Salary");

                Console.Write("Remote (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out bool remote)) throw new Exception("Invalid Boolean");

                list.AddLast(new Employee { Dept = dept, Salary = salary, IsRemote = remote });
            }

            static void UpdateEmployee()
            {
                Console.Write("Index to change: ");
                if (!int.TryParse(Console.ReadLine(), out int index)) throw new Exception("Invalid Index format");

                Console.Write("New Salary: ");
                if (!double.TryParse(Console.ReadLine(), out double salary)) throw new Exception("Invalid Salary");

                list[index].Salary = salary;
            }

            static void PrintTable(EmployeeList targetList)
            {
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine($"{"Department",-10} | {"Salary",-10} | {"Remote",-10}");
                Console.WriteLine("-------------------------------------------");

                if (targetList.Length == 0)
                {
                    Console.WriteLine("List is empty.");
                    return;
                }

                Employee current = targetList.GetFirst();
                while (current != null)
                {
                    Console.WriteLine(current);
                    current = targetList.GetNext();
                }
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"Total Nodes: {targetList.Length} | Avg Salary: {targetList.GetAverageSalary():C}");
            }
        }
    }
}
