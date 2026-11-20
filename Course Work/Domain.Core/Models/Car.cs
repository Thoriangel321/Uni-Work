using System;

namespace Domain.Core.Models
{
    public class Car : BaseEntity
    {
        private string _brand = "Unknown";
        private string _model = "Unknown";
        private string _licensePlate = "AA0000AA";
        private int _year = 2000;
        private string _ownerName = "Unknown";

        public string Brand
        {
            get => _brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Car brand cannot be empty.");
                _brand = value.Trim();
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Car model cannot be empty.");
                _model = value.Trim();
            }
        }

        public string LicensePlate
        {
            get => _licensePlate;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("License plate cannot be empty.");
                _licensePlate = value.Trim().ToUpper();
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year + 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Invalid manufacturing year.");
                _year = value;
            }
        }

        public string OwnerName
        {
            get => _ownerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Owner name cannot be empty.");
                _ownerName = value.Trim();
            }
        }

        public Car()
        {
        }

        public Car(string brand, string model, string licensePlate, int year, string ownerName)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Year = year;
            OwnerName = ownerName;
        }

        public override string GetSummary()
        {
            return $"{Brand} {Model} ({Year}) | Plate: {LicensePlate} | Owner: {OwnerName}";
        }
    }
}