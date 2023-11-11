namespace CarDealMVC.Services
{
    public interface ICachedService<T> where T : class
    {
        public IEnumerable<T> Get(int rowsNumber = 20);
        public void Add(string cacheKey, int rowsNumber = 20);
        public IEnumerable<T> Get(string cacheKey, int rowsNumber = 20);
    }
}
