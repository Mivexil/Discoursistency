using System;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;

namespace Discoursistency.Base.Authentication
{
    /// <summary>
    /// The part of the base interface responsible for handling client authentication.
    /// </summary>
    public interface IDiscourseAuthenticationService
    {
        /// <summary>
        /// Retrieves a CSRF token to use in subsequent request.
        /// </summary>
        /// <param name="incomingData">Authentication data already owned by the client.</param>
        /// <returns>New authentication data, with updated CSRF token.</returns>
        Task<AuthenticationData> GetCSRFToken(AuthenticationData incomingData);
        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="incomingData">Authentication data already owned by the client.</param>
        /// <param name="loginData">User data required for login.</param>
        /// <returns>New authentication data, with updated cookie.</returns>
        Task<AuthenticationData> Login(AuthenticationData incomingData, LoginRequestData loginData);
    }
}