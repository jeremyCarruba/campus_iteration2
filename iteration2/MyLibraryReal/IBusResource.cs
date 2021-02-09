using MyLibraryReal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    public interface IBusResource
    {
        IRequestHandler RequestHandler { get; set; }
        List<Buses> GetBusesNearClassroom(int dist, string longi, string lati);
        Line GetLineDetails(string line);

        List<BusLine> GetAll(int dist, string longi, string lat);
    }
}
