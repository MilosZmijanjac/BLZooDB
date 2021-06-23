namespace BLZooDB.Model
{
    public class Smjestaj
    {
        public int Smjestaj_id { get; set; }
        public string Smjestaj_naziv { get; set; }

        public Smjestaj(int smjestaj_id, string smjestaj_naziv)
        {
            Smjestaj_id = smjestaj_id;
            Smjestaj_naziv = smjestaj_naziv;
        }
    }
}
