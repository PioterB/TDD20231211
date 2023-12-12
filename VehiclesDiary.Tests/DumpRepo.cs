using System;
using System.Collections.Generic;
using System.Linq;
using VehicleDiary.Logic;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    internal class DumpRepo : IRepository<string, Vehicle>
    {
        private Func<bool> _exists = () => false;

        private IDictionary<string, int> _removeCalls = new Dictionary<string, int>();

        public void Add(string key, Vehicle item)
        {
        }

        public void OnExists(Func<bool> action) 
        {
            _exists = action;
        }

        public bool Exists(string key)
        {
            return _exists();
        }

        public Vehicle Get(string key)
        {
            return null;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return Array.Empty<Vehicle>();
        }

        public void Remove(string key)
        {
            if(!_removeCalls.ContainsKey(key)) 
            {
                _removeCalls[key] = 0; 
            }
            _removeCalls[key]++;
        }

        public int RemoveCalls(string key)
        { 
            if(!_removeCalls.ContainsKey(key)) return 0;
            return _removeCalls[key]; 
        }

        public int RemoveCalls()
        {
            return _removeCalls.Values.Sum();
        }
    }
}