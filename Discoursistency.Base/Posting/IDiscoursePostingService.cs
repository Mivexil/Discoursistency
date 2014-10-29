using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Posting;

namespace Discoursistency.Base.Posting
{
    /// <summary>
    /// The part of the base interface responsible for content creation and manipulation.
    /// </summary>
    public interface IDiscoursePostingService
    {
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