namespace Web_TARpv22.Models
{
    public class Toode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public ICollection<KasutajaToode> KasutajaToode { get; set; } = new List<KasutajaToode>();

        public Toode(int id, string name, double price, bool isActive)
        {
            Id = id;
            Name = name;
            Price = price;
            IsActive = isActive;
        }
    }
}
