using System;

namespace Domain.Core.Models
{
    public class SparePart : BaseEntity, IComparable<SparePart>
    {
        private string _name = "Unknown";
        private string _article = "0000";
        private decimal _price = 1m;
        private int _stockQuantity;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Spare part name cannot be empty.");
                _name = value.Trim();
            }
        }

        public string Article
        {
            get => _article;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Article number cannot be empty.");
                _article = value.Trim().ToUpper();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Spare part price must be greater than 0.");
                _price = value;
            }
        }

        public int StockQuantity
        {
            get => _stockQuantity;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Stock quantity cannot be negative.");
                _stockQuantity = value;
            }
        }

        public SparePart()
        {
        }

        public SparePart(string name, string article, decimal price, int stockQuantity)
        {
            Name = name;
            Article = article;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public int CompareTo(SparePart? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string GetSummary()
        {
            return $"{Name} [Art: {Article}] | Price: ${Price:F2} | Stock: {StockQuantity} pcs.";
        }
    }
}