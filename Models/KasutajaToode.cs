using System.Xml.Linq;

namespace Web_TARpv22.Models
{
    public class KasutajaToode
    {
        public int Id { get; set; }

        public int KasutajaId { get; set; }
        public Kasutaja? Kasutaja { get; set; }

        public int ToodeId { get; set; }
        public Toode? Toode { get; set; }

        public int Kokku { get; set; }  // Added Quantity to track the number of products

        // Parameterless constructor required by Entity Framework
        public KasutajaToode() { }

        // Optional parameterized constructor for convenience
        public KasutajaToode(int id, int kasutajaId, Kasutaja kasutaja, int toodeId, Toode toode, int kokku = 1)
        {
            Id = id;
            KasutajaId = kasutajaId;
            Kasutaja = kasutaja;
            ToodeId = toodeId;
            Toode = toode;
            Kokku = kokku;
        }
    }
}
