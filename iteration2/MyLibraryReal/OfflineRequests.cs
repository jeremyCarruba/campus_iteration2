using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iteration2
{
    class OfflineRequests : IRequestHandler
    {
        public string SendRequest(string url)
        {
            string fake = "";
            if (url.Contains("linesNear"))
            {
               fake = "[{\"id\":\"SEM: 1986\",\"name\":\"Grenoble, Caserne de Bonne\",\"lon\":5.72533,\"lat\":45.18506,\"zone\":\"SEM_GENCASBONNE\",\"lines\":[\"SEM: 16\"]}]";
            } else
            {
                fake = File.ReadAllText(@"../../lines.json");
            }
            return fake;
        }
    }
}
