using System.DirectoryServices.AccountManagement;
using common;

namespace ADConnector
{
    public class DCConnector: IAuthenticator
    {
        PrincipalContext _context;

        public bool Connect(string server)
        {
            try
            {
                this._context = new PrincipalContext(ContextType.Domain, server);
            }
            catch { return false; }
            return true;
        }

        public bool Connect(string authuser, string authpw, string authdomain, string server)
        {
            try
            {
                this._context = new PrincipalContext(ContextType.Domain, server, authdomain + "\\" + authuser, authpw);
            }
            catch { return false; }
            return true;
        }
    }
}
