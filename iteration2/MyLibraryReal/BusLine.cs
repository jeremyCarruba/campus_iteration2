using iteration2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryReal
{
    public class BusLine
    {
        public string id { get; set; }
        public string name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string zone { get; set; }
        public List<Line> lines { get; set; }
    }
}
