namespace Web_TARpv22.Models
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nimi { get; set; }
        public string Perenimi { get; set; }

        public ICollection<KasutajaToode> KasutajaToode { get; set; } = new List<KasutajaToode>();


        public Kasutaja(int id, string username, string password, string nimi, string perenimi)
        {
            Id = id;
            Username = username;
            Password = password;
            Nimi = nimi;
            Perenimi = perenimi;
        }
    }
}
