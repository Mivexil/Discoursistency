using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Authentication;
using Discoursistency.Base.CategoryRetrieving;
using Discoursistency.Base.MessageBus;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.CategoryRetrieving;
using Discoursistency.Base.Models.MessageBus;
using Discoursistency.Base.Models.NotificationRetrieving;
using Discoursistency.Base.Models.Posting;
using Discoursistency.Base.Models.PostRetrieving;
using Discoursistency.Base.Models.UserActionRetrieving;
using Discoursistency.Base.Models.UserRetrieving;
using Discoursistency.Base.NotificationRetrieving;
using Discoursistency.Base.Posting;
using Discoursistency.Base.PostRetrieving;
using Discoursistency.Base.UserActionRetrieving;
using Discoursistency.Base.UserRetrieving;
using Discoursistency.HTTP.Client;

namespace Discoursistency.Base
{
    public class DiscourseBaseService : IDiscourseBaseService
    {
        private readonly IClient _webClient;
        private readonly IBaseAuthenticationService _authentication;
        private readonly IBasePostingService _posting;
        private readonly IBasePostRetrievalService _postRetrieving;
        private readonly IBaseNotificationRetrievalService _notificationRetrieving;
        private readonly IBaseUserActionRetrievalService _userActionRetrieving;
        private readonly IBaseUserRetrievalService _userRetrieving;
        private readonly IBaseMessageBusService _messageBus;
        private readonly IBaseCategoryRetrievalService _categoryRetrieving;
        public DiscourseBaseService(string siteURL, int requestsPerSecond = 5)
        {
            _webClient = new Client(siteURL, requestsPerSecond);
            _authentication = new BaseAuthenticationService(_webClient);
            _posting = new BasePostingService(_webClient);
            _postRetrieving = new BasePostRetrievalService(_webClient);
            _notificationRetrieving = new BaseNotificationRetrievalService(_webClient);
            _userActionRetrieving = new BaseUserActionRetrievalService(_webClient);
            _userRetrieving = new BaseUserRetrievalService(_webClient);
            _messageBus = new BaseMessageBusService(_webClient);
            _categoryRetrieving = new BaseCategoryRetrievalService(_webClient);
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }

        public async Task<AuthenticationData> GetCSRFToken(AuthenticationData incomingData)
        {
            return await _authentication.GetCSRFToken(incomingData);
        }

        public async Task<AuthenticationData> Login(AuthenticationData incomingData, LoginRequestData loginData)
        {
            return await _authentication.Login(incomingData, loginData);
        }

        public async Task CreatePost(AuthenticationData authData, NewPostRequest postData)
        {
            await _posting.CreatePost(authData, postData);
        }

        public async Task PerformPostAction(AuthenticationData authData, PerformPostActionRequest actionData)
        {
            await _posting.PerformPostAction(authData, actionData);
        }

        public async Task DeletePostAction(AuthenticationData authData, PerformPostActionRequest actionData)
        {
            await _posting.DeletePostAction(authData, actionData);
        }

        public async Task Timings(AuthenticationData authData, TimingsRequest timings)
        {
            await _posting.Timings(authData, timings);
        }

        public async Task EditPost(AuthenticationData authData, EditPostRequest editData)
        {
            await _posting.EditPost(authData, editData);
        }

        public async Task DeletePost(AuthenticationData authData, DeletePostRequest deleteData)
        {
            await _posting.DeletePost(authData, deleteData);
        }

        public async Task<MultiplePostsModel> GetMultiplePosts(AuthenticationData authData, GetMultiplePostsRequest requestData)
        {
            return await _postRetrieving.GetMultiplePosts(authData, requestData);
        }

        public async Task<PostModel> GetPost(AuthenticationData authData, GetPostRequest getPostData)
        {
            return await _postRetrieving.GetPost(authData, getPostData);
        }

        public async Task<UserModel> GetUserData(AuthenticationData authData, UserRequest userData)
        {
            return await _userRetrieving.GetUserData(authData, userData);
        }

        public async Task<IEnumerable<UserActionModel>> GetUserActions(AuthenticationData authData,
            UserActionRequest actionData)
        {
            return await _userActionRetrieving.GetUserActions(authData, actionData);
        }

        public async Task<IEnumerable<NotificationModel>> GetNotifications(AuthenticationData authData)
        {
            return await _notificationRetrieving.GetNotifications(authData);
        }

        public async Task<IEnumerable<NotificationModel>> GetNotificationHistory(AuthenticationData authData,
            NotificationHistoryRequest historyData)
        {
            return await _notificationRetrieving.GetNotificationHistory(authData, historyData);
        }

        public async Task<IEnumerable<MessageBusResponse>> PollMessageBus(AuthenticationData authData,
            MessageBusRequest msgData)
        {
            return await _messageBus.PollMessageBus(authData, msgData);
        }

        public async Task<string> GetRawPost(AuthenticationData authData, GetPostByTopicRequest postData)
        {
            return await _postRetrieving.GetRawPost(authData, postData);
        }

        public async Task<TopicModel> GetTopic(AuthenticationData authData, TopicRequest requestData)
        {
            return await _postRetrieving.GetTopic(authData, requestData);
        }

        public async Task<TopicListResponse> GetLatest(AuthenticationData authData, TopicListRequest requestData)
        {
            return await _postRetrieving.GetLatest(authData, requestData);
        }
        public async Task<TopicListResponse> GetNew(AuthenticationData authData, TopicListRequest requestData)
        {
            return await _postRetrieving.GetNew(authData, requestData);
        }
        public async Task<TopicListResponse> GetUnread(AuthenticationData authData, TopicListRequest requestData)
        {
            return await _postRetrieving.GetUnread(authData, requestData);
        }

        public async Task<CategoryListResponse> GetCategories(AuthenticationData authData)
        {
            return await _categoryRetrieving.GetCategories(authData);
        }
    }
}
