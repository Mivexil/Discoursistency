using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the response status code indicates a failure.
    /// </summary>
    public class StatusCodeException : Exception
    {
        /// <summary>
        /// The status code of the faulty response.
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Content of the faulty response.
        /// </summary>
        public HTTPClientContent Response { get; set; }
        public StatusCodeException(int statusCode, HTTPClientContent serverResponse)
            : base("Unexpected status code: " + statusCode + ", " +
                   "server responded: " + 
                    (serverResponse.ToString().Length > 100 
                        ? serverResponse.ToString().Substring(0, 100) + "..."
                        : serverResponse.ToString()))
        {
            StatusCode = statusCode;
            Response = serverResponse;
        }
    }
}
