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
        string Response { get; set; }
        string OfflineResponse { get; set; }
        void GetResponse(int dist);
        List<Buses> TransformResponse();

        Line GetLineDetails(string line);
    }
}
