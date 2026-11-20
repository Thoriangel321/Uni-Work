using System;

namespace Domain.Core.Models
{
    public class Mechanic : BaseEntity
    {
        private string _fullName = "Unknown";
        private string _specialization = "General";
        private decimal _hourlyRate = 100m;
        private bool _isBusy;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mechanic full name cannot be empty.");
                _fullName = value.Trim();
            }
        }

        public string Specialization
        {
            get => _specialization;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Specialization cannot be empty.");
                _specialization = value.Trim();
            }
        }

        public decimal HourlyRate
        {
            get => _hourlyRate;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Hourly rate must be greater than 0.");
                _hourlyRate = value;
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => _isBusy = value;
        }

        public Mechanic()
        {
        }

        public Mechanic(string fullName, string specialization, decimal hourlyRate)
        {
            FullName = fullName;
            Specialization = specialization;
            HourlyRate = hourlyRate;
        }

        public override string GetSummary()
        {
            string status = IsBusy ? "Busy" : "Available";
            return $"{FullName} ({Specialization}) | Rate: ${HourlyRate:F2}/hr | Status: {status}";
        }
    }
}