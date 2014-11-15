using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.CategoryRetrieving;
using Discoursistency.Base.Models.MessageBus;
using Discoursistency.Base.Models.NotificationRetrieving;
using Discoursistency.Base.Models.Posting;
using Discoursistency.Base.Models.PostRetrieving;
using Discoursistency.Base.Models.UserActionRetrieving;
using Discoursistency.Base.Models.UserRetrieving;

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
        Task CreatePost(AuthenticationData authData, NewPostRequest postData);
        /// <summary>
        /// Issues a request to perform one of the post actions.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="actionData">Information about the action.</param>
        /// <returns></returns>
        Task PerformPostAction(AuthenticationData authData, PerformPostActionRequest actionData);
        /// <summary>
        /// Issues a request to undo the post action.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="actionData">Information about the action being deleted.</param>
        /// <returns></returns>
        Task DeletePostAction(AuthenticationData authData, PerformPostActionRequest actionData);
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
        Task EditPost(AuthenticationData authData, EditPostRequest editData);
        /// <summary>
        /// Issues a request to delete the post.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="deleteData">Information about the deletion.</param>
        /// <returns></returns>
        Task DeletePost(AuthenticationData authData, DeletePostRequest deleteData);
        /// <summary>
        /// Issues a request to obtain multiple posts from the topic.
        /// </summary>
        /// <param name="authData">Client authentication data.</param>
        /// <param name="requestData">Information about the posts requested.</param>
        /// <returns></returns>
        Task<MultiplePostsModel> GetMultiplePosts(AuthenticationData authData,
            GetMultiplePostsRequest requestData);
        /// <summary>
        /// Issues a request to obtain a single post from the topic.
        /// </summary>
        /// <param name="authData"></param>
        /// <param name="getPostData"></param>
        /// <returns></returns>
        Task<PostModel> GetPost(AuthenticationData authData, GetPostRequest getPostData);
        Task<UserModel> GetUserData(AuthenticationData authData, UserRequest userData);
        Task<IEnumerable<UserActionModel>> GetUserActions(AuthenticationData authData, UserActionRequest actionData);
        Task<IEnumerable<NotificationModel>> GetNotifications(AuthenticationData authData);
        Task<IEnumerable<NotificationModel>> GetNotificationHistory(AuthenticationData authData,
            NotificationHistoryRequest historyData);
        Task<IEnumerable<MessageBusResponse>> PollMessageBus(AuthenticationData authData,
            MessageBusRequest msgData);
        Task<string> GetRawPost(AuthenticationData authData, GetPostByTopicRequest postData);
        Task<TopicModel> GetTopic(AuthenticationData authData, TopicRequest requestData);
        Task<TopicListResponse> GetLatest(AuthenticationData authData, TopicListRequest requestData);
        Task<TopicListResponse> GetNew(AuthenticationData authData, TopicListRequest requestData);
        Task<TopicListResponse> GetUnread(AuthenticationData authData, TopicListRequest requestData);
        Task<CategoryListResponse> GetCategories(AuthenticationData authData);
    }
}