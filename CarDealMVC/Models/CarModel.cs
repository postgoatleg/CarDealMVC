namespace CarDealMVC.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }

        public string? ModelName { get; set; }



        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
