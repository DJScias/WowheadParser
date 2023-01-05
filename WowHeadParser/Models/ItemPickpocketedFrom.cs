using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemPickpocketedFrom
    {
        public int classification { get; set; }
        public int id { get; set; }
        public int[] location { get; set; }
        public int maxlevel { get; set; }
        public int minlevel { get; set; }
        public string name { get; set; }
        public int?[] react { get; set; }
        public int type { get; set; }
        public int count { get; set; }
        public int outof { get; set; }
        public string pctstack { get; set; }
        public string tag { get; set; }
    }

}
