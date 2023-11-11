namespace CarDealMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Adres { get; set; }

        public string? Telephone { get; set; }

        public string? PassportData { get; set; }

        public int? CarId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? SaleDate { get; set; }

        public bool? IsPayed { get; set; }

        public virtual Car? Car { get; set; }

    }
}
