using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        private int _id { get;  set; }
        private string _prefix { get; set; }
        public string Id => $"{_prefix}#{_id}";

        public BaseEntity(int id, string prefix)
        {
            _id = id;
            _prefix = prefix;
        }

        public abstract string GetInfo();
    }
}
