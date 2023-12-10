﻿using System.Collections.Generic;
using System.Linq;

namespace VehiclesDiary.Tools.Persistence
{
    public class InMemoryRepository<TKey, TItem>
    {
        private readonly IDictionary<TKey, TItem> _store = new Dictionary<TKey, TItem>();

        public void Add(TKey key, TItem item)
        {
            _store.Add(key, item);
        }

        public bool Exists(TKey key)
        {
            return _store.ContainsKey(key);
        }

        public IEnumerable<TItem> GetAll()
        {
            return _store.Values.ToArray();
        }

        public TItem Get(TKey key)
        {
            if (_store.ContainsKey(key) == false)
            {
                return default(TItem);
            }

            return _store[key];
        }

        public void Remove(TKey key)
        {
            _store.Remove(key);
        }
    }

}