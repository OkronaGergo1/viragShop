using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace viragShop.Models
{
    internal class Viragok
    {
        public Viragok()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }
        public int Ar { get; set; }
        public int Mennyiseg { get; set; }


        public Viragok(string nev, string leiras, int ar, int mennyiseg)
        {
            Nev = nev;
            Leiras = leiras;
            Ar = ar;
            Mennyiseg = mennyiseg;
        }
    }
}
