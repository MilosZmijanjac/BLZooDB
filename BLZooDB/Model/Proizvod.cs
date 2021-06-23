using System;

namespace BLZooDB.Model
{
   public class Proizvod {
        public int ProizvodId { get; set; }
        public string Velicina { get; set; }
        public string Naziv { get; set; }
        public int ShopId { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }

        private string Slika;

        public string SlikaProperty
        {
            get { return "Images/img/" + Slika; }
            set { Slika = value; }
        }

        public int PotrebnaKolicina { get; set; }
        public string ShopKategorija { get; set; }

        public Proizvod(int proizvodId, string velicina, string naziv, int shopId, decimal cijena, int kolicina, string slika, int potrebnaKolicina, string shopKategorija)
        {
            ProizvodId = proizvodId;
            Velicina = velicina ?? throw new ArgumentNullException(nameof(velicina));
            Naziv = naziv ?? throw new ArgumentNullException(nameof(naziv));
            ShopId = shopId;
            Cijena = cijena;
            Kolicina = kolicina;
            Slika = slika ?? throw new ArgumentNullException(nameof(slika));
            PotrebnaKolicina = potrebnaKolicina;
            ShopKategorija = shopKategorija ?? default(string);
        }
    }
}

