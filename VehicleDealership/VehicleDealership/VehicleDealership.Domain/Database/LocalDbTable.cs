using System;
using System.Collections.Generic;
using System.Linq;
using VehicleDealership.Domain.Interfaces;
using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Database
{
    public class LocalDbTable<T> : IDbTable<T> where T : BaseEntity
    {
        private List<T> _table;

        public LocalDbTable()
        {
            _table = new List<T>();
        }

        public List<T> GetAll()
        {
            return _table;
        }

        public T GetById(string id)
        {
            T entity = _table.FirstOrDefault(x => x.Id == id);

            if(entity == null)
            {
                throw new Exception($"There is no ID {id} found!");
            }

            return entity;
        }

        public void Insert(T entity)
        {
            _table.Add(entity);
        }

        public void RemoveById(string id)
        {
            T entity = _table.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"There is no ID {id} found!");
            }

            _table.Remove(entity);
        }
    }
}
