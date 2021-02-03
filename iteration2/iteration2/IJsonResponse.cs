using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    public interface IJsonResponse
    {
        string Response { get; set; }
        string OfflineResponse { get; set; }

        void GenerateResponse();
    }
}
