using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLZooDB.Model
{
    public class LogIn
    {
        public string Pozicija { get; set; }
        public string Id { get; set; }
        public LogIn(string poz,string id)
        {
            Pozicija = poz;
            Id = id;
        }
    }
}
