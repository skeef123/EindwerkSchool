using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.prop
{
    public class Adres
    {
        public Adres(int id, int straatID, int huisnummer, int appartementnummer, int busnummer, string huisnummerlabel, int adreslocatieID, int postcode)
        {
            Id = id;
            StraatID = straatID;
            Huisnummer = huisnummer;
            Appartementnummer = appartementnummer;
            Busnummer = busnummer;
            Huisnummerlabel = huisnummerlabel;
            AdreslocatieID = adreslocatieID;
            Postcode = postcode;
        }

        public int Id { get; set; }
        public int StraatID { get; set; }
        public int Huisnummer { get; set; }
        public int Appartementnummer { get; set; }
        public int Busnummer { get; set; }
        public string Huisnummerlabel { get; set; }
        public int AdreslocatieID { get; set; }
        public int Postcode { get; set; }

    }
}