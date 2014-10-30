using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;

namespace Discoursistency.Base.Models.Authentication
{
    /// <summary>
    /// A model representing a response from CSRF token issuing controller.
    /// </summary>
    public class CSRFResponse
    {
        public string csrf { get; set; }

    }
}
