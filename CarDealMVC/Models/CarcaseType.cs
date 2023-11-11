namespace CarDealMVC.Models
{
    public class CarcaseType
    {
        public int CarcaseTypeId { get; set; }

        public string? TypeName { get; set; }

        public string? TypeDescription { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
