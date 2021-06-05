using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.prop
{
    public class Straat
    {
        public Straat(int id, string straatNaam, string nIScode)
        {
            Id = id;
            StraatNaam = straatNaam;
            NIScode = nIScode;
        }

        public int Id { get; set; }
        public string StraatNaam { get; set; }
        public string NIScode { get; set; }

      
    }

}
