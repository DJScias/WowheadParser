using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowHeadParser.Models
{
    public class ItemObjectiveOfQuest
    {
        public int category { get; set; }
        public int category2 { get; set; }
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public int[][] reprewards { get; set; }
        public int reqlevel { get; set; }
        public int side { get; set; }
        public int wflags { get; set; }
        public int classs { get; set; }
        public int[][] itemchoices { get; set; }
        public int race { get; set; }
        public int reqclass { get; set; }
        public int reqrace { get; set; }
        public int xp { get; set; }
        public int daily { get; set; }
        public int[][] itemrewards { get; set; }
        public int money { get; set; }
    }

}
