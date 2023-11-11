using CarDealMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CarDealMVC.Services
{
    public class CachedCarsService : ICachedService<Car>
    {
        private readonly CarDealerContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public CachedCarsService(CarDealerContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public IEnumerable<Car> Get(int rowsNumber = 20)
        {
            return _dbContext.Cars.Take(rowsNumber).ToList();
        }

        public void Add(string cacheKey, int rowsNumber = 20)
        {
            IEnumerable<Car> cars = _dbContext.Cars.Take(rowsNumber).ToList();
            if (cars != null)
            {
                _memoryCache.Set(cacheKey, cars, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(268)
                });

            }

        }


        public IEnumerable<Car> Get(string cacheKey, int rowsNumber = 20)
        {
            IEnumerable<Car> cars;
            if (!_memoryCache.TryGetValue(cacheKey, out cars))
            {
                cars = _dbContext.Cars.Take(rowsNumber).ToList();
                if (cars != null)
                {
                    _memoryCache.Set(cacheKey, cars,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(268)));
                }
            }
            return cars;
        }
    }
}
