using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Discoursistency.HTTP.Client.Models
{
    /// <summary>
    /// Represents a request to be issued to the server.
    /// </summary>
    public class HTTPClientRequest
    {
        /// <summary>
        /// A method to be used when sending the request.
        /// </summary>
        public HttpMethod Method { get; set; }
        /// <summary>
        /// A subpage to which the request will be sent.
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// Cookie and CSRF token to validate and authenticate the request.
        /// </summary>
        public AuthData Headers { get; set; }
        /// <summary>
        /// An object to be sent together with the request.
        /// </summary>
        public object Content { get; set; }
        private bool _asXmlHttpRequest = true;
        /// <summary>
        /// Whether to mock an AJAX request by sending X-Requested-With : XmlHttpRequest header.
        /// </summary>
        public bool AsXmlHttpRequest
        {
            get { return _asXmlHttpRequest; }
            set { _asXmlHttpRequest = value; }
        }
    }
}
