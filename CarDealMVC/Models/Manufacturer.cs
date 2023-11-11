namespace CarDealMVC.Models
{
    public class Manufacturer
    {
     public int ManufacturerId { get; set; }

    public string? ManufacturerName { get; set; }

    public string? Country { get; set; }

    public string? Adres { get; set; }

    public string? ExtraDescription { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
