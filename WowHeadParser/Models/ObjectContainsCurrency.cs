using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ObjectContainsCurrency
    {
        public int id { get; set; }
        public int category { get; set; }
        public string icon { get; set; }
        public Modes modes { get; set; }
        public int count { get; set; }
        public int[] stack { get; set; }
    }

}
