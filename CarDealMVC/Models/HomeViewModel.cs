using CarDealMVC.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace CarDealMVC.Models
{
    public class HomeViewModel
    {
        CarDealerContext _context;
        public IEnumerable<Car> Cars { get; set; }
        ICachedService<Car> CachedService;
        public HomeViewModel(CarDealerContext context) 
        { 
            _context = context;
            CachedService = context.GetService<ICachedService<Car>>();
            Cars = CachedService.Get("cars");
            Cars = (from c in Cars
                   join m in _context.CarModels on c.ModelId equals m.CarModelId
                   select new Car
                   {
                       CarId = c.CarId,
                       RegistrationNumber = c.RegistrationNumber,
                       ModelId = c.ModelId,
                       ManufacturerId = c.ManufacturerId,
                       Photo = c.Photo,
                       CarcaseTypeId = c.CarcaseTypeId,
                       ReleaseYear = c.ReleaseYear,
                       Color = c.Color,
                       EngineNumber = c.EngineNumber,
                       CarsStats = c.CarsStats,
                       Price = c.Price,
                       SellerEmployeeId = c.SellerEmployeeId,
                       CarcaseType = c.CarcaseType,
                       CarsEquipments = c.CarsEquipments,
                       Clients = c.Clients,
                       Manufacturer = c.Manufacturer,
                       Model = m,
                       SellerEmployee = c.SellerEmployee
                   }).ToList();

        }

    }
}
