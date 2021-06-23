using System;

namespace BLZooDB.Model
{
    public class Zivotinja
    {
        public int Zivotinja_id { get; set; }
        public string Ime { get; set; }
        public string Zivotinja_vrsta { get; set; }
        public DateTime Datum_prijema { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string Spol { get; set; }
        public int Smjestaj_id { get; set; }
        public string Zdravstveno_stanje { get; set; }
        public string Tip_ishrane { get; set; }
        public int Broj_hranjenja_dnevno { get; set; }

        private string Putanja_do_slike;
        public string SlikaProperty
        {
            get { return "Images/img/" + Putanja_do_slike; }
            set { Putanja_do_slike = value; }
        }

        public Zivotinja(int zivotinja_id, string ime, string zivotinja_vrsta, DateTime datum_prijema, DateTime datum_rodjenja,
            string spol, int smjestaj_id, string zdravstveno_stanje, string tip_ishrane,
            int broj_hranjenja_dnevno, string slikaProperty)
        {
            Zivotinja_id = zivotinja_id;
            Ime = ime;
            Zivotinja_vrsta = zivotinja_vrsta;
            Datum_prijema = datum_prijema;
            Datum_rodjenja = datum_rodjenja;
            Spol = spol;
            Smjestaj_id = smjestaj_id;
            Zdravstveno_stanje = zdravstveno_stanje;
            Tip_ishrane = tip_ishrane;
            Broj_hranjenja_dnevno = broj_hranjenja_dnevno;
            SlikaProperty = slikaProperty;
        }
    }
}
