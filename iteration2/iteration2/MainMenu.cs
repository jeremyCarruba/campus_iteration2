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

                Console.WriteLine("Tu veux quoi ? [bus/exit]");
                string userLineInput = Console.ReadLine();
                if (userLineInput == "bus")
                {
                    this.GetBusesFromPoint();
                } else if (userLineInput == "exit")
                {
                    break;
                }
            }


        }

        public void GetBusesFromPoint()
        {
            Console.WriteLine("Quelle distance de l'école ?");
            int dist = Int32.Parse(Console.ReadLine());

            this.MC.DisplayBusesPretty(dist);
        }
    }
}
