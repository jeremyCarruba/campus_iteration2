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


    
    }
}
