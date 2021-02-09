using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    public class RequestHandler : IRequestHandler
    {
        public string SendRequest(string url)
        {
            string finalResponse = "empty";
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusDescription == "OK")
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                finalResponse = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }

            return finalResponse;
        }
    }
}
