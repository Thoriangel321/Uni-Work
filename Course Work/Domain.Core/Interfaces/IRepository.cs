using System;
using System.Collections.Generic;
using Domain.Core.Models;

namespace Domain.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        bool Remove(T item);
        T? GetById(Guid id);
        List<T> GetAll();
        List<T> Find(Predicate<T> match);
        void ReplaceAll(IEnumerable<T> items);
    }
}