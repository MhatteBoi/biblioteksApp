using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotekApp
{
    public class Lånetagare
    {
        public string namn {  get; set; }
        public int personNr {  get; set; }
        public List<string> lånadeBöcker {  get; set; }

        public Lånetagare(int personNr, string namn)
        {
            this.personNr = personNr;
            this.namn = namn;
            lånadeBöcker = new List<string>();
            
        }
    }
}
