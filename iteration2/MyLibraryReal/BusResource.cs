using MyLibraryReal;
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
        public List<Buses> GetBusesNearClassroom(int dist, string longi, string lat)
        {
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

        public List<BusLine> GetAll(int dist, string longi, string lat)
        {
            List<BusLine> busLineList = new List<BusLine>();
            List<Buses> buses = this.GetBusesNearClassroom(dist, longi, lat);
            buses.ForEach(bus =>
            {
                List<Line> lineList = new List<Line>();
                bus.lines.ForEach(line => lineList.Prepend(this.GetLineDetails(line))
                );
                BusLine bl = new BusLine();
                bl.lines = lineList;
                bl.name = bus.name;
                bl.id = bus.id;
                bl.lon = bus.lon;
                bl.zone = bus.zone;
                bl.lat = bus.lat;
                busLineList.Prepend(bl);
            });
            return busLineList;
        }

        // methode qui s'occupe des requetes, string url ==> string json, ensuite on fait ce qu'on veut avec, même objet pour toutes les requetes
        // une classe qui gere toutes les requetes, des classes qui deserialise ensuite
    }
}
