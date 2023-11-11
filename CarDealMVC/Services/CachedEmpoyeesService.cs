using CarDealMVC.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CarDealMVC.Services
{
    public class CachedEmpoyeesService : ICachedService<Employee>
    {
        private readonly CarDealerContext _dbContext;
        private readonly IMemoryCache _memoryCache;

        public CachedEmpoyeesService(CarDealerContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public void Add(string cacheKey, int rowsNumber = 20)
        {
            IEnumerable<Employee> emps =
                (from e in _dbContext.Employees
                 join p in _dbContext.Positions on e.PositionId equals p.PositionId
                 select new Employee
                 {
                     EmployeeId = e.EmployeeId,
                     FirstName = e.FirstName,
                     LastName = e.LastName,
                     Position = p,
                     Age = e.Age,
                     PositionId = e.PositionId
                 }).Take(rowsNumber).ToList();//_dbContext.Employees.Take(rowsNumber).ToList();
            if (emps != null)
            {
                _memoryCache.Set(cacheKey, emps, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(268)
                });

            }
        }

        public IEnumerable<Employee> Get(int rowsNumber = 20)
        {
            return (from e in _dbContext.Employees
                    join p in _dbContext.Positions on e.PositionId equals p.PositionId
                    select new Employee
                    {
                        EmployeeId = e.EmployeeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Position = p,
                        Age = e.Age,
                        PositionId = e.PositionId
                    }).Take(rowsNumber).ToList();
        }

        public IEnumerable<Employee> Get(string cacheKey, int rowsNumber = 20)
        {
            IEnumerable<Employee> emps;
            if (!_memoryCache.TryGetValue(cacheKey, out emps))
            {
                emps = (from e in _dbContext.Employees
                        join p in _dbContext.Positions on e.PositionId equals p.PositionId
                        select new Employee
                        {
                            EmployeeId = e.EmployeeId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Position = p,
                            Age = e.Age,
                            PositionId = e.PositionId
                        }).Take(rowsNumber).ToList(); ;
                if (emps != null)
                {
                    _memoryCache.Set(cacheKey, emps,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(268)));
                }
            }
            return emps;
        }
    }
}
