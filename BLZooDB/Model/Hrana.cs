namespace BLZooDB.Model
{
    public class Hrana
    {
        public int Hrana_id { get; set; }
        public string Naziv { get; set; }
        public int Stanje { get; set; }
        public int Potrebno_stanje { get; set; }

        public Hrana(int hrana_id, string naziv, int stanje, int potrebnoStanje)
        {
            Hrana_id = hrana_id;
            Naziv = naziv;
            Stanje = stanje;
            Potrebno_stanje = potrebnoStanje;
        }
    }
}
