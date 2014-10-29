using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Authentication
{
    /// <summary>
    /// A class representing client's authentication data.
    /// </summary>
    public class AuthenticationData
    {
        /// <summary>
        /// A cookie authenticating the user.
        /// </summary>
        public string Cookie { get; set; }
        /// <summary>
        /// A CSRF token required to validate the request.
        /// </summary>
        public string CSRFToken { get; set; }
    }
}
