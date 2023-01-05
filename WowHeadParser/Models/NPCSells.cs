using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class NPCSells
    {
        public Appearances appearances { get; set; }
        public int armor { get; set; }
        public int[] bonustrees { get; set; }
        public int classs { get; set; }
        public int displayid { get; set; }
        public int flags2 { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int quality { get; set; }
        public int reqlevel { get; set; }
        public int slot { get; set; }
        public int slotbak { get; set; }
        public int[] source { get; set; }
        public int[] specs { get; set; }
        public int subclass { get; set; }
        public int standing { get; set; }
        public int?[] react { get; set; }
        public int[] stack { get; set; }
        public int avail { get; set; }
        public int[] cost { get; set; }
        public bool commondrop { get; set; }
        public Sourcemore[] sourcemore { get; set; }
    }

}
