namespace CarDealMVC.Models
{
    public class CarsEquipment
    {
        public int CarsEquipmentId { get; set; }

        public int? CarId { get; set; }

        public int? EquipmentId { get; set; }

        public virtual Car? Car { get; set; }

        public virtual ExtraEquipment? Equipment { get; set; }
    }
}
