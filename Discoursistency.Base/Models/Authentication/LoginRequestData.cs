using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Authentication
{
    /// <summary>
    /// A model representing a request to log the user in.
    /// </summary>
    public class LoginRequestData
    {
        /// <summary>
        /// Username of the user being logged in.
        /// </summary>
        public string login { get; set; }
        /// <summary>
        /// Password of the user being logged in.
        /// </summary>
        public string password { get; set; }
    }
}
