using MyLibraryReal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    class MainMenu
    {
        public MainController MC { get; set; }

        public MainMenu()
        {
            this.Init();
        }
        public void Init()
        {
            while (true)
            {
                Console.WriteLine("Coucou, mode en ligne ? [Y/n]");
                MainController.Statuses status = MainController.Statuses.OFFLINE;
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.Y)
                {
                    status = MainController.Statuses.ONLINE;
                }
                this.MC = new MainController(status);

                Console.WriteLine("Tu veux quoi ? [bus/buslines/exit]");
                string userLineInput = Console.ReadLine();
                if (userLineInput == "bus")
                {
                    this.GetBusesFromPoint();
                }else if(userLineInput == "buslines")
                {
                    this.GetAll();
                }
                else if (userLineInput == "exit")
                {
                    break;
                }
            }


        }

        public void GetBusesFromPoint()
        {
            Console.WriteLine("Quelle distance de l'école ?");
            int dist = Int32.Parse(Console.ReadLine());

            this.DisplayBusesPretty(dist);
        }

        public void GetAll()
        {
            Console.WriteLine("Quelle distance de l'école ?");
            int dist = Int32.Parse(Console.ReadLine());
            string longi = "5.728043";
            string lat = "45.184320";

            List<BusLine> bl = this.MC.BusResource.GetAll(dist, longi, lat);
            Console.WriteLine(bl);
        }

        public void DisplayBusesPretty(int dist)
        {
            string longi = "5.728043";
            string lat = "45.184320";
            List<Buses> busList = this.MC.BusResource.GetBusesNearClassroom(dist, longi, lat);
            busList.ForEach(bus =>
            {
                Console.WriteLine("arret: " + bus.name + ", lignes: ");
                bus.lines.ForEach(line =>
                {
                    Console.WriteLine("=============*****========");
                    Console.WriteLine(line);
                    Console.WriteLine("============******========");
                    Line lineDeser = this.MC.BusResource.GetLineDetails(line);
                    Console.WriteLine(lineDeser.features[0].properties.LIBELLE);
                });
            });

        }
    }
}
