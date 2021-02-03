using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    class JsonResponse : IJsonResponse
    {
        public string Response { get; set; }
        public string OfflineResponse { get; set; }

        public JsonResponse()
        {
            this.GenerateResponse();
            this.OfflineResponse = "Offline Response";
        }
        public void GenerateResponse()
        {
            string finalResponse = "No response";
            WebRequest request = WebRequest.Create("https://data.mobilites-m.fr/api/linesNear/json?x=5.728043&y=45.184320&dist=500&details=true");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusDescription == "OK")
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                finalResponse = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }

            this.Response = finalResponse;
        }

    }
}
