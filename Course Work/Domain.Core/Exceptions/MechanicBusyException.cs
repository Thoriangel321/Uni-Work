using System;

namespace Domain.Core.Exceptions
{
    public class MechanicBusyException : Exception
    {
        private readonly string _mechanicName;

        public string MechanicName => _mechanicName;

        public MechanicBusyException(string mechanicName)
            : base($"Mechanic {mechanicName} is currently busy with another order.")
        {
            _mechanicName = mechanicName;
        }
    }
}