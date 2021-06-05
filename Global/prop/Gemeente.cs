using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.prop
{
    public class Gemeente
    {
        public Gemeente(string nIScode, string gemeenteNaam)
        {
            NIScode = nIScode;
            GemeenteNaam = gemeenteNaam;
        }

        public string NIScode { get; set; }
        public string GemeenteNaam { get; set; }


    }
}
