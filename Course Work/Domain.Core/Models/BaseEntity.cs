using System;

namespace Domain.Core.Models
{
    public abstract class BaseEntity
    {
        private Guid _id = Guid.NewGuid();

        public Guid Id
        {
            get => _id;
            set => _id = value == Guid.Empty ? Guid.NewGuid() : value;
        }

        public abstract string GetSummary();

        public override string ToString()
        {
            return GetSummary();
        }
    }
}