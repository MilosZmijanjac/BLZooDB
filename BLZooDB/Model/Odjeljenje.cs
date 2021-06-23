using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLZooDB.Model
{
    public class Odjeljenje
    {
        public int Odjeljenje_id { get; set; }

        public string Odjeljenje_naziv { get; set; }

        public int Rukovodilac_id { get; set; }

        public Odjeljenje(int odjeljenje_id, string odjeljenje_naziv, int rukovodilac_id)
        {
            Odjeljenje_id = odjeljenje_id;
            Odjeljenje_naziv = odjeljenje_naziv;
            Rukovodilac_id = rukovodilac_id;
        }
    }
}
