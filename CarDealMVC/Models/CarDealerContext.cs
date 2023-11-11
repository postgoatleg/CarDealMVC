using Microsoft.EntityFrameworkCore;

namespace CarDealMVC.Models
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions<CarDealerContext> options) : base(options) 
        {

        }

        public CarDealerContext() { }

        public  DbSet<Car> Cars { get; set; }

        public  DbSet<CarModel> CarModels { get; set; }

        public  DbSet<CarcaseType> CarcaseTypes { get; set; }

        public  DbSet<CarsEquipment> CarsEquipments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ExtraEquipment> ExtraEquipments { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Position> Positions { get; set; }
    }
}
