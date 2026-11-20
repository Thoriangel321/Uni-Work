using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Core.Interfaces;
using Domain.Core.Models;

namespace Domain.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public T? GetById(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        public List<T> Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));
            return _items.FindAll(match);
        }

        public void ReplaceAll(IEnumerable<T> items)
        {
            _items.Clear();
            if (items != null)
            {
                _items.AddRange(items);
            }
        }
    }
}