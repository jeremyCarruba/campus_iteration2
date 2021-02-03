
using System;
using System.Net;


namespace iteration2
{
    class Program
    {

        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            Console.WriteLine("Coucou, mode en ligne ? [Y/n]");
            MainController.Statuses status = MainController.Statuses.OFFLINE;
            ConsoleKeyInfo userInput = Console.ReadKey();
            if(userInput.Key == ConsoleKey.Y)
            {
                status = MainController.Statuses.ONLINE;
            }
            MainController mainController = new MainController(status);

            Console.WriteLine(mainController.GetCloseBuses(new JsonResponse()));
        }
    }
}
