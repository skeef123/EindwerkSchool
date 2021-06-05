using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.prop
{
    public class AdresLocatie
    {
        public AdresLocatie(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

      
    }
}
