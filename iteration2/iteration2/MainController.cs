using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    public class MainController
    {
        public Statuses Status { get; set; }

        public enum Statuses
        {
            OFFLINE,
            ONLINE
        }

        public MainController(Statuses status)
        {
            this.Status = status;
        }
        public string GetCloseBuses(IBusResource response)
        {
            string data;
            if(this.Status == Statuses.OFFLINE)
            {
                 data = response.OfflineResponse;
            }
            else
            {
                data = response.Response;
            }
            return data;
        }

        public void DisplayBusesPretty(IBusResource response)
        {
            Console.WriteLine("Les beaux bus");
            List<Buses> busList = response.TransformResponse();
            busList.ForEach(bus =>
            {
                Console.WriteLine("arret: " + bus.name + ", lignes: ");
                bus.lines.ForEach(line => {
                    Console.WriteLine(line);
                    Line lineDeser = response.GetLineDetails(line);
                    Console.WriteLine(lineDeser.features[0].properties.LIBELLE);

                });
            });
        }
    }
}
