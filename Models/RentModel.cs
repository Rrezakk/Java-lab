namespace Java.Models
{
    public class RentModel
    {
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int CarId { get; set; }
        public int Days { get; set; }
        public RentModel() { }
        public RentModel(int renterId, int carId, int days)
        {
            RenterId = renterId;
            CarId = carId;
            Days = days;
        }
    }
}
