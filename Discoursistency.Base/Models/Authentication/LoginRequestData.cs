using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.Base.Models.Authentication
{
    /// <summary>
    /// A model representing a request to log the user in.
    /// </summary>
    public class LoginRequestData
    {
        public string login { get; set; }
        public string password { get; set; }
    }
}
