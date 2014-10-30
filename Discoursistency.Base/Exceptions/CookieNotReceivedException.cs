using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Exceptions
{
    public class CookieNotReceivedException : Exception
    {
        /// <summary>
        /// The exception that is thrown when the client expected a Set-Cookie header to be set, but did not receive any or received an invalid one.
        /// </summary>
        public CookieNotReceivedException()
            : base("Expected cookie has not been sent from the server.")
        {
            
        }

        public CookieNotReceivedException(Exception e)
            : base("Expected cookie has not been sent from the server.", e)
        {
            
        }
    }
}
