using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{

    public class ItemContainedInItem
    {
        public int classs { get; set; }
        public int flags2 { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public int slot { get; set; }
        public int subclass { get; set; }
        public int count { get; set; }
        public int outof { get; set; }
        public string pctstack { get; set; }
        public int popularity { get; set; }
    }
}
