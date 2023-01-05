using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemSoldBy
    {
        public int classification { get; set; }
        public int id { get; set; }
        public int[] location { get; set; }
        public string name { get; set; }
        public int?[] react { get; set; }
        public string tag { get; set; }
        public int type { get; set; }
        public int stock { get; set; }
        public int[] cost { get; set; }
        public int stack { get; set; }
        public int popularity { get; set; }
    }

}
