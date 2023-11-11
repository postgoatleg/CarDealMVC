using CarDealMVC.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CarDealMVC.Services
{
    public class CachedManufacturersService : ICachedService<Manufacturer>
    {
        private readonly CarDealerContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public CachedManufacturersService(CarDealerContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public void Add(string cacheKey, int rowsNumber = 20)
        {
            IEnumerable<Manufacturer> manufacturers = (IEnumerable<Manufacturer>)_dbContext.Manufacturers.Take(rowsNumber).ToList();
            if (manufacturers != null)
            {
                _memoryCache.Set(cacheKey, manufacturers, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(268)
                });

            }
        }

        public IEnumerable<Manufacturer> Get(int rowsNumber = 20)
        {
            return (IEnumerable<Manufacturer>)_dbContext.Manufacturers.Take(rowsNumber).ToList();
        }

        public IEnumerable<Manufacturer> Get(string cacheKey, int rowsNumber = 20)
        {
            IEnumerable<Manufacturer> manufacturers;
            if (!_memoryCache.TryGetValue(cacheKey, out manufacturers))
            {
                manufacturers = (IEnumerable<Manufacturer>)_dbContext.Manufacturers.Take(rowsNumber).ToList();
                if (manufacturers != null)
                {
                    _memoryCache.Set(cacheKey, manufacturers,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(268)));
                }
            }
            return manufacturers;
        }
    }
}
