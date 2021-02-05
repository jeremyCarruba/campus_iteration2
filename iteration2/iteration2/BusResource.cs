using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    class BusResource : IBusResource
    {
        public string Response { get; set; }
        public string OfflineResponse { get; set; }

        public BusResource(int dist)
        {
            this.GetResponse(dist);
            this.OfflineResponse = "Offline Response";
        }
        public void GetResponse(int dist)
        {
            string finalResponse = "No response";
            string longi = "5.728043";
            string lat = "45.184320";
            string url = "https://data.mobilites-m.fr/api/linesNear/json?x=" + longi + "&y=" + lat + "&dist=" + dist + "&details=true";
            Console.WriteLine(url);
            WebRequest request = WebRequest.Create(url);
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

        public List<Buses> TransformResponse()
        {
            return JsonConvert.DeserializeObject<List<Buses>>(this.Response);
        }

        public Line GetLineDetails(string line)
        {
            string[] splitted = line.Split(':');
            WebRequest request = WebRequest.Create("http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=" + splitted[0] + "_" + splitted[1]);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Line>(json);
        }

        // methode qui s'occupe des requetes, string url ==> string json, ensuite on fait ce qu'on veut avec, même objet pour toutes les requetes
        // une classe qui gere toutes les requetes, des classes qui deserialise ensuite
    }
}
