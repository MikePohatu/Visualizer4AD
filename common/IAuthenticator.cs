using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public interface IAuthenticator
    {
        bool Connect(string server);
        bool Connect(string authuser, string authpw, string authdomain, string server);
    }
}
