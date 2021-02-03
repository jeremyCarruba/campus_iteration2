using iteration2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2test
{
    class JsonResponseTest : IJsonResponse
    {
        public string Response { get ; set ; }
        public string OfflineResponse { get; set; }

        public JsonResponseTest()
        {
            this.GenerateResponse();
        }
        public void GenerateResponse()
        {
            this.Response = "Test Response";
            this.OfflineResponse = "Offline Test Response";
        }
    }
}
