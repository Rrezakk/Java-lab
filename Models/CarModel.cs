namespace Java.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Serial { get; set; }
        public string State { get; set; }
        public int Price { get; set; }
        public CarModel() { }
        public CarModel(string name, string color, string serial, string state, int price)
        {
            Name = name;
            Color = color;
            Serial = serial;
            State = state;
            Price = price;
        }
    }
}
