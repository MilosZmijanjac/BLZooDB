using System;

namespace BLZooDB.Model
{
    public class Lijek
    {
        public int Lijek_id { get; set; }
        public string Lijek_naziv { get; set; }

        public int Stanje { get; set; }

        public int Potrebno_stanje { get; set; }

        public Lijek( int lijek_id, string naziv)
        {
            Lijek_naziv = naziv ?? throw new ArgumentNullException(nameof(naziv));
            Lijek_id = lijek_id;
        }

        public Lijek(int lijek_id, string lijek_naziv, int stanje, int potrebno_stanje) : this(lijek_id, lijek_naziv)
        {
            Stanje = stanje;
            Potrebno_stanje = potrebno_stanje;
        }
    }
}
