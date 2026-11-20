using System;
using System.Collections.Generic;
using Domain.Core.Exceptions;
using Domain.Core.Models;
using Domain.Core.Services;

namespace Domain.UI
{
    public class ConsoleMenu
    {
        private readonly RepairShopService _service;

        public ConsoleMenu(RepairShopService service)
        {
            _service = service;
        }

        public void Run()
        {
            _service.LoadAll();
            Console.WriteLine("Auto repair shop data loaded successfully.");

            bool isRunning = true;
            while (isRunning)
            {
                PrintMenu();
                int choice = InputHelper.ReadInt("Select a menu option: ", 0, 12);
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddCarMenu();
                            break;
                        case 2:
                            PrintList(_service.GetAllCars(), "Cars List");
                            break;
                        case 3:
                            SearchCarsMenu();
                            break;
                        case 4:
                            AddMechanicMenu();
                            break;
                        case 5:
                            PrintList(_service.GetAllMechanics(), "Mechanics List");
                            break;
                        case 6:
                            AddSparePartMenu();
                            break;
                        case 7:
                            PrintList(_service.GetSortedSparePartsByPrice(), "Spare Parts (Sorted by Price)");
                            break;
                        case 8:
                            CreateOrderMenu();
                            break;
                        case 9:
                            AssignMechanicMenu();
                            break;
                        case 10:
                            AddPartToOrderMenu();
                            break;
                        case 11:
                            CompleteOrderMenu();
                            break;
                        case 12:
                            PrintList(_service.GetSortedOrdersByCost(), "Repair Orders (Sorted by Cost)");
                            break;
                        case 0:
                            _service.SaveAll();
                            Console.WriteLine("Data saved to JSON. Exiting application.");
                            isRunning = false;
                            break;
                    }
                }
                catch (PartOutOfStockException ex)
                {
                    Console.WriteLine($"[Stock Error]: {ex.Message}");
                }
                catch (MechanicBusyException ex)
                {
                    Console.WriteLine($"[Assignment Error]: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error]: {ex.Message}");
                }

                Console.WriteLine();
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("=== AUTO REPAIR SHOP ===");
            Console.WriteLine("1. Add car");
            Console.WriteLine("2. View all cars");
            Console.WriteLine("3. Search cars by brand");
            Console.WriteLine("4. Add mechanic");
            Console.WriteLine("5. View all mechanics");
            Console.WriteLine("6. Add spare part to stock");
            Console.WriteLine("7. View spare parts stock (sorted by price)");
            Console.WriteLine("8. Create repair order");
            Console.WriteLine("9. Assign mechanic to order");
            Console.WriteLine("10. Add spare part to order");
            Console.WriteLine("11. Complete order and calculate total");
            Console.WriteLine("12. View all orders (sorted by cost)");
            Console.WriteLine("0. Save data and exit");
        }

        private void AddCarMenu()
        {
            string brand = InputHelper.ReadString("Brand: ");
            string model = InputHelper.ReadString("Model: ");
            string plate = InputHelper.ReadString("License plate: ");
            int year = InputHelper.ReadInt("Manufacturing year: ", 1900, DateTime.Now.Year + 1);
            string owner = InputHelper.ReadString("Owner full name: ");

            _service.AddCar(new Car(brand, model, plate, year, owner));
            Console.WriteLine("Car added successfully.");
        }

        private void SearchCarsMenu()
        {
            string brand = InputHelper.ReadString("Enter brand to search: ");
            var found = _service.FindCarsByBrand(brand);
            PrintList(found, $"Search results for '{brand}'");
        }

        private void AddMechanicMenu()
        {
            string name = InputHelper.ReadString("Mechanic full name: ");
            string spec = InputHelper.ReadString("Specialization: ");
            decimal rate = InputHelper.ReadDecimal("Hourly rate: ", 1);

            _service.AddMechanic(new Mechanic(name, spec, rate));
            Console.WriteLine("Mechanic added successfully.");
        }

        private void AddSparePartMenu()
        {
            string name = InputHelper.ReadString("Spare part name: ");
            string article = InputHelper.ReadString("Article number: ");
            decimal price = InputHelper.ReadDecimal("Unit price: ", 0.01m);
            int quantity = InputHelper.ReadInt("Stock quantity: ", 0, 100000);

            _service.AddSparePart(new SparePart(name, article, price, quantity));
            Console.WriteLine("Spare part added to stock.");
        }

        private void CreateOrderMenu()
        {
            var cars = _service.GetAllCars();
            if (cars.Count == 0)
            {
                Console.WriteLine("Please add at least one car first.");
                return;
            }

            PrintList(cars, "Select a car");
            int index = InputHelper.ReadInt("Car number from the list: ", 1, cars.Count) - 1;
            string problem = InputHelper.ReadString("Problem description: ");
            decimal laborCost = InputHelper.ReadDecimal("Labor cost: ", 0);

            var order = _service.CreateOrder(cars[index].Id, problem, laborCost);
            Console.WriteLine($"Order created. Estimated cost: ${order.CalculateTotalCost():F2}.");
        }

        private void AssignMechanicMenu()
        {
            var orders = _service.GetAllOrders();
            var mechanics = _service.GetAllMechanics();

            if (orders.Count == 0 || mechanics.Count == 0)
            {
                Console.WriteLine("At least one order and one mechanic are required.");
                return;
            }

            PrintList(orders, "Select an order");
            int orderIndex = InputHelper.ReadInt("Order number: ", 1, orders.Count) - 1;

            PrintList(mechanics, "Select a mechanic");
            int mechIndex = InputHelper.ReadInt("Mechanic number: ", 1, mechanics.Count) - 1;

            _service.AssignMechanic(orders[orderIndex].Id, mechanics[mechIndex].Id);
            Console.WriteLine($"Mechanic {mechanics[mechIndex].FullName} assigned successfully.");
        }

        private void AddPartToOrderMenu()
        {
            var orders = _service.GetAllOrders();
            var parts = _service.GetAllSpareParts();

            if (orders.Count == 0 || parts.Count == 0)
            {
                Console.WriteLine("At least one order and one spare part in stock are required.");
                return;
            }

            PrintList(orders, "Select an order");
            int orderIndex = InputHelper.ReadInt("Order number: ", 1, orders.Count) - 1;

            PrintList(parts, "Select a spare part");
            int partIndex = InputHelper.ReadInt("Spare part number: ", 1, parts.Count) - 1;

            int quantity = InputHelper.ReadInt("Quantity: ", 1, 1000);

            _service.AddPartToOrder(orders[orderIndex].Id, parts[partIndex].Id, quantity);
            Console.WriteLine($"Spare part added. New total order cost: ${orders[orderIndex].CalculateTotalCost():F2}.");
        }

        private void CompleteOrderMenu()
        {
            var orders = _service.GetAllOrders();
            if (orders.Count == 0)
            {
                Console.WriteLine("The orders list is empty.");
                return;
            }

            PrintList(orders, "Select an order to complete");
            int orderIndex = InputHelper.ReadInt("Order number: ", 1, orders.Count) - 1;

            var order = orders[orderIndex];
            _service.CompleteOrder(order.Id);

            Console.WriteLine("Order completed!");
            Console.WriteLine($"Labor cost: ${order.LaborCost:F2}");
            Console.WriteLine($"Parts cost: ${order.CalculatePartsCost():F2}");
            Console.WriteLine($"Total amount due: ${order.CalculateTotalCost():F2}");
        }

        private void PrintList<T>(List<T> items, string title) where T : BaseEntity
        {
            Console.WriteLine($"--- {title} ---");
            if (items.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].GetSummary()}");
            }
        }
    }
}