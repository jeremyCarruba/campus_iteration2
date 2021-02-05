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
        public IRequestHandler RequestHandler { get; set; }
        public BusResource(IRequestHandler requestHandler)
        {
            this.RequestHandler = requestHandler;
        }
        public List<Buses> GetBusesNearClassroom(int dist)
        {
            string longi = "5.728043";
            string lat = "45.184320";
            string url = "https://data.mobilites-m.fr/api/linesNear/json?x=" + longi + "&y=" + lat + "&dist=" + dist + "&details=true";

            string finalResponse = this.RequestHandler.SendRequest(url);
            return JsonConvert.DeserializeObject<List<Buses>>(finalResponse);
        }

        public Line GetLineDetails(string line)
        {
            string[] splitted = line.Split(':');
            string url = "http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=" + splitted[0] + "_" + splitted[1];
            string json = this.RequestHandler.SendRequest(url);
            return JsonConvert.DeserializeObject<Line>(json);
        }

        // methode qui s'occupe des requetes, string url ==> string json, ensuite on fait ce qu'on veut avec, même objet pour toutes les requetes
        // une classe qui gere toutes les requetes, des classes qui deserialise ensuite
    }
}
