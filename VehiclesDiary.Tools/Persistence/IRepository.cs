using System.Collections.Generic;

namespace VehiclesDiary.Tools.Persistence
{
    public interface IRepository<in TKey, TItem>
    {
        void Add(TKey key, TItem item);

        bool Exists(TKey key);

        IEnumerable<TItem> GetAll();

        TItem Get(TKey key);

        void Remove(TKey key);
    }
}