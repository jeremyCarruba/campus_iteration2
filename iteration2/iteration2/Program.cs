
using System;
using System.Net;


namespace iteration2
{
    class Program
    {

        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            MainMenu menu = new MainMenu();
        }
    }
}
