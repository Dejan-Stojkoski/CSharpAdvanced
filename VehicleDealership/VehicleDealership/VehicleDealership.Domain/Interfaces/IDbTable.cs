using System.Collections.Generic;
using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Interfaces
{
    public interface IDbTable<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(string id);
        void Insert(T entity);
        void RemoveById(string id);
    }
}
