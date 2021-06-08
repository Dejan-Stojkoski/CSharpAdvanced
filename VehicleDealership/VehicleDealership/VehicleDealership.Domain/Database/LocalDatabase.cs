using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Database
{
    public static class LocalDatabase
    {
        public static LocalDbTable<Buyer> Buyers { get; set; } = new LocalDbTable<Buyer>();
        public static LocalDbTable<SalesPerson> SalesPeople { get; set; } = new LocalDbTable<SalesPerson>();
        public static LocalDbTable<ProcurementPerson> ProcurementPeople { get; set; } = new LocalDbTable<ProcurementPerson>();
        public static LocalDbTable<Vehicle> Vehicles { get; set; } = new LocalDbTable<Vehicle>();
        public static LocalDbTable<Trailer> Trailers { get; set; } = new LocalDbTable<Trailer>();
        public static LocalDbTable<Order> Orders { get; set; } = new LocalDbTable<Order>();

    }
}
