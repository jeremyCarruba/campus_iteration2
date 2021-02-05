using iteration2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2test
{
    public class FakeRequests : IRequestHandler
    {
        public string SendRequest(string url)
        {
            return "[{\"id\":\"SEM: 1986\",\"name\":\"Grenoble, Caserne de Bonne\",\"lon\":5.72533,\"lat\":45.18506,\"zone\":\"SEM_GENCASBONNE\",\"lines\":[\"SEM: 16\"]}]";
        }
    }
}
