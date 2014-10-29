using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.HTTP.Client
{
    /// <summary>
    /// An HTTP client which issues the requests to the server.
    /// </summary>
    public interface IClient : IDisposable
    {
        /// <summary>
        /// Sends a request to the server.
        /// </summary>
        /// <param name="request">Parameters of the request.</param>
        /// <returns>Response from the server.</returns>
        Task<HTTPClientResponse> IssueRequest(HTTPClientRequest request);
    }
}