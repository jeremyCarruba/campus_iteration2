using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iteration2
{
    public interface IRequestHandler
    {
        string SendRequest(string url);
    }
}
