using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Models
{
    public class RepairOrder : BaseEntity
    {
        private Car _vehicle = new Car();
        private Mechanic? _assignedMechanic;
        private string _problemDescription = "Diagnostics";
        private decimal _laborCost;
        private List<SparePart> _usedParts = new List<SparePart>();
        private bool _isCompleted;
        private DateTime _createdAt = DateTime.Now;

        public Car Vehicle
        {
            get => _vehicle;
            set => _vehicle = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Mechanic? AssignedMechanic
        {
            get => _assignedMechanic;
            set => _assignedMechanic = value;
        }

        public string ProblemDescription
        {
            get => _problemDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Problem description cannot be empty.");
                _problemDescription = value.Trim();
            }
        }

        public decimal LaborCost
        {
            get => _laborCost;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Labor cost cannot be negative.");
                _laborCost = value;
            }
        }

        public List<SparePart> UsedParts
        {
            get => _usedParts;
            set => _usedParts = value ?? new List<SparePart>();
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set => _isCompleted = value;
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public RepairOrder()
        {
        }

        public RepairOrder(Car vehicle, string problemDescription, decimal laborCost)
        {
            Vehicle = vehicle;
            ProblemDescription = problemDescription;
            LaborCost = laborCost;
        }

        public decimal CalculatePartsCost()
        {
            return _usedParts.Sum(p => p.Price * p.StockQuantity);
        }

        public decimal CalculateTotalCost()
        {
            return LaborCost + CalculatePartsCost();
        }

        public override string GetSummary()
        {
            string mechanicInfo = AssignedMechanic != null ? AssignedMechanic.FullName : "Unassigned";
            string status = IsCompleted ? "Completed" : "In Progress";
            return $"[{CreatedAt:dd.MM.yyyy}] {Vehicle.Brand} {Vehicle.Model} ({Vehicle.LicensePlate}) | " +
                   $"Issue: {ProblemDescription} | Mechanic: {mechanicInfo} | " +
                   $"Labor: ${LaborCost:F2} | Parts: ${CalculatePartsCost():F2} | " +
                   $"Total: ${CalculateTotalCost():F2} | Status: {status}";
        }
    }
}