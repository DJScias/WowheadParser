using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemMinedFromObject
    {
        public int id { get; set; }
        public int[] location { get; set; }
        public string name { get; set; }
        public int skill { get; set; }
        public int type { get; set; }
        public int count { get; set; }
        public int outof { get; set; }
        public string pctstack { get; set; }
        public int popularity { get; set; }
    }

}
