using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemFishedIn
    {
        public int category { get; set; }
        public int id { get; set; }
        public int maxlevel { get; set; }
        public int minlevel { get; set; }
        public string name { get; set; }
        public int territory { get; set; }
        public string count { get; set; }
        public int outof { get; set; }
        public string pctstack { get; set; }
        public int popularity { get; set; }
        public int expansion { get; set; }
        public int nplayers { get; set; }
    }
}
