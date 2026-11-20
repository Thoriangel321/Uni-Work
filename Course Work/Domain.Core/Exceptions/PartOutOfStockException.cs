using System;

namespace Domain.Core.Exceptions
{
    public class PartOutOfStockException : Exception
    {
        private readonly string _partName;
        private readonly int _availableQuantity;
        private readonly int _requestedQuantity;

        public string PartName => _partName;
        public int AvailableQuantity => _availableQuantity;
        public int RequestedQuantity => _requestedQuantity;

        public PartOutOfStockException(string partName, int availableQuantity, int requestedQuantity)
            : base($"Insufficient '{partName}' in stock. Available: {availableQuantity}, requested: {requestedQuantity}.")
        {
            _partName = partName;
            _availableQuantity = availableQuantity;
            _requestedQuantity = requestedQuantity;
        }
    }
}