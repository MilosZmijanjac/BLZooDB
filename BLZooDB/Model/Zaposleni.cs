using System;

namespace BLZooDB.Model
{
    public class Zaposleni
    {
        public int Zaposleni_id { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Nadredjeni_id { get; set; }
        public int Odjel_id { get; set; }
        public string Odjel_naziv { get; set; }
        public string Nadredjeni_naziv { get; set; }

        private string ImePrezime;

        public string ImePrezimeProperty
        {
            get { return Ime+" "+Prezime; }
            set { ImePrezime = value; }
        }

        public Zaposleni(int zaposleni_id, string lozinka, string ime, string prezime, int nadredjeni_id, int odjel_id, string odjel_naziv, string nadredjeni_naziv) : this(zaposleni_id, lozinka, ime, prezime, nadredjeni_id, odjel_id)
        {
            Odjel_naziv = odjel_naziv;
            Nadredjeni_naziv = nadredjeni_naziv;
        }

        public Zaposleni(int zaposleni_id, string lozinka, string ime, string prezime, int nadredjeni_id, int odjel_id)
        {
            this.Zaposleni_id = zaposleni_id;
            this.Lozinka = lozinka ?? throw new ArgumentNullException(nameof(lozinka));
            this.Ime = ime ?? throw new ArgumentNullException(nameof(ime));
            this.Prezime = prezime ?? throw new ArgumentNullException(nameof(prezime));
            this.Nadredjeni_id = nadredjeni_id;
            this.Odjel_id = odjel_id ;
        }
    }
}
