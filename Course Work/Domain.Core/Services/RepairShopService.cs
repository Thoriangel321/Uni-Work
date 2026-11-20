using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Core.Comparers;
using Domain.Core.Exceptions;
using Domain.Core.Interfaces;
using Domain.Core.Models;
using Domain.Core.Repositories;

namespace Domain.Core.Services
{
    public class RepairShopService
    {
        private readonly IRepository<Car> _cars = new Repository<Car>();
        private readonly IRepository<Mechanic> _mechanics = new Repository<Mechanic>();
        private readonly IRepository<SparePart> _parts = new Repository<SparePart>();
        private readonly IRepository<RepairOrder> _orders = new Repository<RepairOrder>();

        private readonly JsonFileService<Car> _carStorage;
        private readonly JsonFileService<Mechanic> _mechanicStorage;
        private readonly JsonFileService<SparePart> _partStorage;
        private readonly JsonFileService<RepairOrder> _orderStorage;

        public RepairShopService(string dataDirectory = "Data")
        {
            _carStorage = new JsonFileService<Car>(Path.Combine(dataDirectory, "cars.json"));
            _mechanicStorage = new JsonFileService<Mechanic>(Path.Combine(dataDirectory, "mechanics.json"));
            _partStorage = new JsonFileService<SparePart>(Path.Combine(dataDirectory, "parts.json"));
            _orderStorage = new JsonFileService<RepairOrder>(Path.Combine(dataDirectory, "orders.json"));
        }

        public void LoadAll()
        {
            _cars.ReplaceAll(_carStorage.Load());
            _mechanics.ReplaceAll(_mechanicStorage.Load());
            _parts.ReplaceAll(_partStorage.Load());
            _orders.ReplaceAll(_orderStorage.Load());
        }

        public void SaveAll()
        {
            _carStorage.Save(_cars.GetAll());
            _mechanicStorage.Save(_mechanics.GetAll());
            _partStorage.Save(_parts.GetAll());
            _orderStorage.Save(_orders.GetAll());
        }

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public List<Car> GetAllCars()
        {
            return _cars.GetAll();
        }

        public List<Car> FindCarsByBrand(string brand)
        {
            return _cars.Find(c => c.Brand.Contains(brand, StringComparison.OrdinalIgnoreCase));
        }

        public void AddMechanic(Mechanic mechanic)
        {
            _mechanics.Add(mechanic);
        }

        public List<Mechanic> GetAllMechanics()
        {
            return _mechanics.GetAll();
        }

        public List<Mechanic> GetAvailableMechanics()
        {
            return _mechanics.Find(m => !m.IsBusy);
        }

        public void AddSparePart(SparePart part)
        {
            _parts.Add(part);
        }

        public void RestockSparePart(Guid partId, int addedQuantity)
        {
            if (addedQuantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(addedQuantity), "Restock quantity must be greater than 0.");

            var part = _parts.GetById(partId) ?? throw new ArgumentException("Spare part not found.");
            part.StockQuantity += addedQuantity;
        }

        public List<SparePart> GetAllSpareParts()
        {
            return _parts.GetAll();
        }

        public List<SparePart> GetSortedSparePartsByPrice()
        {
            var list = _parts.GetAll();
            list.Sort();
            return list;
        }

        public RepairOrder CreateOrder(Guid carId, string problemDescription, decimal laborCost)
        {
            var car = _cars.GetById(carId) ?? throw new ArgumentException("Car not found.");
            var order = new RepairOrder(car, problemDescription, laborCost);
            _orders.Add(order);
            return order;
        }

        public List<RepairOrder> GetAllOrders()
        {
            return _orders.GetAll();
        }

        public List<RepairOrder> GetSortedOrdersByCost()
        {
            var list = _orders.GetAll();
            list.Sort(new OrderCostComparer());
            return list;
        }

        public void AssignMechanic(Guid orderId, Guid mechanicId)
        {
            var order = _orders.GetById(orderId) ?? throw new ArgumentException("Repair order not found.");
            var mechanic = _mechanics.GetById(mechanicId) ?? throw new ArgumentException("Mechanic not found.");

            if (order.IsCompleted)
                throw new InvalidOperationException("Cannot change the mechanic for a completed order.");

            if (mechanic.IsBusy)
                throw new MechanicBusyException(mechanic.FullName);

            if (order.AssignedMechanic != null)
            {
                var previousMechanic = _mechanics.GetById(order.AssignedMechanic.Id);
                if (previousMechanic != null)
                    previousMechanic.IsBusy = false;
            }

            mechanic.IsBusy = true;
            order.AssignedMechanic = mechanic;
        }

        public void AddPartToOrder(Guid orderId, Guid partId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0.");

            var order = _orders.GetById(orderId) ?? throw new ArgumentException("Repair order not found.");
            var part = _parts.GetById(partId) ?? throw new ArgumentException("Spare part not found.");

            if (order.IsCompleted)
                throw new InvalidOperationException("Cannot add spare parts to a completed order.");

            if (part.StockQuantity < quantity)
                throw new PartOutOfStockException(part.Name, part.StockQuantity, quantity);

            part.StockQuantity -= quantity;

            var existingUsedPart = order.UsedParts.FirstOrDefault(p => p.Id == part.Id);
            if (existingUsedPart != null)
            {
                existingUsedPart.StockQuantity += quantity;
            }
            else
            {
                var usedPart = new SparePart(part.Name, part.Article, part.Price, quantity)
                {
                    Id = part.Id
                };
                order.UsedParts.Add(usedPart);
            }
        }

        public void CompleteOrder(Guid orderId)
        {
            var order = _orders.GetById(orderId) ?? throw new ArgumentException("Repair order not found.");

            if (order.IsCompleted)
                throw new InvalidOperationException("Order is already completed.");

            order.IsCompleted = true;

            if (order.AssignedMechanic != null)
            {
                var mechanic = _mechanics.GetById(order.AssignedMechanic.Id);
                if (mechanic != null)
                    mechanic.IsBusy = false;
                order.AssignedMechanic.IsBusy = false;
            }
        }
    }
}