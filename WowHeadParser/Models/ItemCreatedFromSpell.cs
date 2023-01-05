using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemCreatedFromSpell
    {
        public int cat { get; set; }
        public int[] colors { get; set; }
        public int[] creates { get; set; }
        public int id { get; set; }
        public int learnedat { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int nskillup { get; set; }
        public int quality { get; set; }
        public int[][] reagents { get; set; }
        public int schools { get; set; }
        public int[] skill { get; set; }
        public int[] source { get; set; }
        public int trainingcost { get; set; }
    }

}
