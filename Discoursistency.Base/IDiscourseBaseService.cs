using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Posting;

namespace Discoursistency.Base
{
    /// <summary>
    /// The base Discourse service, containing methods used to issue supported requests and retrieve responses as they are returned.
    /// Direct use of this API is discouraged - use the wrappers around most common tasks instead.
    /// //todo create the wrappers, heh.
    /// </summary>
    public interface IDiscourseBaseService : IDisposable
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
        /// <summary>
        /// Issues a request to create a new post.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="postData">Information about the post.</param>
        /// <returns></returns>
        Task CreatePost(AuthenticationData authData, PostRequest postData);
        /// <summary>
        /// Issues a request to perform one of the post actions.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="actionData">Information about the action.</param>
        /// <returns></returns>
        Task PerformPostAction(AuthenticationData authData, PostActionRequest actionData);
        /// <summary>
        /// Issues a request to undo the post action.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="actionData">Information about the action being deleted.</param>
        /// <returns></returns>
        Task DeletePostAction(AuthenticationData authData, PostActionRequest actionData);
        /// <summary>
        /// Issues a timing request to mock post reading.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="timings">Information about time spent on each post.</param>
        /// <returns></returns>
        Task Timings(AuthenticationData authData, TimingsRequest timings);
        /// <summary>
        /// Issues a request to edit a post.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="editData">Information about the edit.</param>
        /// <returns></returns>
        Task EditPost(AuthenticationData authData, PostEditRequest editData);
        /// <summary>
        /// Issues a request to delete the post.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="deleteData">Information about the deletion.</param>
        /// <returns></returns>
        Task DeletePost(AuthenticationData authData, PostDeleteRequest deleteData);
    }
}