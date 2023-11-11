namespace CarDealMVC.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }

        public int? PositionId { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

        public virtual ICollection<Order> Clients { get; set; } = new List<Order>();

        public virtual Position? Position { get; set; }
    }
}
