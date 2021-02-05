using iteration2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2test
{
    class BusResourceTest : IBusResource
    {
        public string Response { get ; set ; }
        public string OfflineResponse { get; set; }

        public BusResourceTest()
        {
            this.GetResponse(100);
        }
        public void GetResponse(int dist)
        {
            this.Response = "[{\"id\":\"SEM: 1986\",\"name\":\"Grenoble, Caserne de Bonne\",\"lon\":5.72533,\"lat\":45.18506,\"zone\":\"SEM_GENCASBONNE\",\"lines\":[\"SEM: 16\"]}]";
            this.OfflineResponse = "Offline Test Response";
        }

        public List<Buses> TransformResponse()
        {
            return JsonConvert.DeserializeObject<List<Buses>>(this.Response);
        }

        public Line GetLineDetails(string line)
        {
            throw new NotImplementedException();
        }
    }
}
