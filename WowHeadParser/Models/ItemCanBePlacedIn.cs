using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemCanBePlacedIn
    {
        public int classs { get; set; }
        public int flags2 { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int nslots { get; set; }
        public int quality { get; set; }
        public int slot { get; set; }
        public int slotbak { get; set; }
        public int[] source { get; set; }
        public int subclass { get; set; }
        public Sourcemore[] sourcemore { get; set; }
    }

}
