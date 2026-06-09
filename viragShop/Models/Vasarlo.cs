using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace viragShop.Models
{
    internal class Vasarlo
    {
        public Vasarlo()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nev { get; set; }
        public int SzulDatum { get; set; }
        public string Lakcim { get; set; }
        public int Iranyitoszam { get; set; }
        public string Jelszo { get; set; }

        public Vasarlo(string nev, int szulDatum, string lakcim, int iranyitoszam, string jelszo)
        {
            Nev = nev;
            SzulDatum = szulDatum;
            Lakcim = lakcim;
            Iranyitoszam = iranyitoszam;
            Jelszo = jelszo;
        }
    }
}
