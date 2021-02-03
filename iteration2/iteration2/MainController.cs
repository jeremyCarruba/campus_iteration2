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
        public string GetCloseBuses(IJsonResponse response)
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
    }
}
