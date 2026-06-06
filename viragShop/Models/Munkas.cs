using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viragShop.Models
{
    internal class Munkas
    {
        public Munkas()
        {
        }

        public int Id { get; set; }
        public string Nev { get; set; }
        public int SzulDatum { get; set; }
        public string Lakcim { get; set; }
        public string Beosztas { get; set; }

        public Munkas(string nev, int szulDatum, string lakcim, string beosztas)
        {
            Nev = nev;
            SzulDatum = szulDatum;
            Lakcim = lakcim;
            Beosztas = beosztas;
        }
    }
}
