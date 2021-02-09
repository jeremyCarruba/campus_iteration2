using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    public class Buses
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string zone { get; set; }
        public List<string> lines { get; set; }
    }
}
