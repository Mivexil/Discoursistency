using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.HTTP.Client.Models
{
    /// <summary>
    /// Represents a response from the server.
    /// </summary>
    public class HTTPClientResponse
    {
        /// <summary>
        /// Status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Indicates whether the request resulted in a success status code.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// A cookie to be set by the client.
        /// </summary>
        public string CookieString { get; set; }
        /// <summary>
        /// Type of the response received from the server.
        /// </summary>
        public ResponseType Type { get; set; }
        /// <summary>
        /// Body of the response.
        /// </summary>
        public HTTPClientContent Content { get; set; }
    }
}
