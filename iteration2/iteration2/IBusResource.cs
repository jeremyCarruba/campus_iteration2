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
        List<Buses> GetBusesNearClassroom(int dist);
        Line GetLineDetails(string line);
    }
}
