using System;
using System.Collections.Generic;

namespace iteration2
{
    public class MainController
    {
        public Statuses Status { get; set; }
        public IRequestHandler RequestHandler { get; set; }
        public IBusResource BusResource { get; set; }

        public enum Statuses
        {
            OFFLINE,
            ONLINE
        }

        public MainController(Statuses status)
        {
            this.Status = status;
            if(status == Statuses.OFFLINE)
            {
                this.RequestHandler = new OfflineRequests();
            } else
            {
                this.RequestHandler = new RequestHandler();
            }
            this.BusResource = new BusResource(this.RequestHandler);
        }


        public void DisplayBusesPretty(int dist)
        {
            List<Buses> busList = this.BusResource.GetBusesNearClassroom(dist);
            busList.ForEach(bus =>
            {
                Console.WriteLine("arret: " + bus.name + ", lignes: ");
                bus.lines.ForEach(line => {
                    Console.WriteLine("=============*****========");
                    Console.WriteLine(line);
                    Console.WriteLine("============******========");
                    Line lineDeser = BusResource.GetLineDetails(line);
                    Console.WriteLine(lineDeser.features[0].properties.LIBELLE);
                });
            });
        }
    }
}
