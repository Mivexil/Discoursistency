using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Authentication;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Posting;
using Discoursistency.Base.Models.Retrieving;
using Discoursistency.Base.Posting;
using Discoursistency.Base.Retrieving;
using Discoursistency.HTTP.Client;

namespace Discoursistency.Base
{
    public class DiscourseBaseService : IDiscourseBaseService
    {
        private readonly IClient _webClient;
        private readonly IDiscourseAuthenticationService _authentication;
        private readonly IDiscoursePostingService _posting;
        private readonly IDiscoursePostRetrievalService _retrieving;
        public DiscourseBaseService(string siteURL, int requestsPerSecond = 5)
        {
            _webClient = new Client(siteURL, requestsPerSecond);
            _authentication = new DiscourseAuthenticationService(_webClient);
            _posting = new DiscoursePostingService(_webClient);
            _retrieving = new DiscoursePostRetrievalService(_webClient);
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

        public async Task CreatePost(AuthenticationData authData, PostRequest postData)
        {
            await _posting.CreatePost(authData, postData);
        }

        public async Task PerformPostAction(AuthenticationData authData, PostActionRequest actionData)
        {
            await _posting.PerformPostAction(authData, actionData);
        }

        public async Task DeletePostAction(AuthenticationData authData, PostActionRequest actionData)
        {
            await _posting.DeletePostAction(authData, actionData);
        }

        public async Task Timings(AuthenticationData authData, TimingsRequest timings)
        {
            await _posting.Timings(authData, timings);
        }

        public async Task EditPost(AuthenticationData authData, PostEditRequest editData)
        {
            await _posting.EditPost(authData, editData);
        }

        public async Task DeletePost(AuthenticationData authData, PostDeleteRequest deleteData)
        {
            await _posting.DeletePost(authData, deleteData);
        }

        public async Task<MultiplePostsModel> GetMultiplePosts(AuthenticationData authData, GetMultiplePostsRequest requestData)
        {
            return await _retrieving.GetMultiplePosts(authData, requestData);
        }

        public async Task<PostModel> GetPost(AuthenticationData authData, GetPostRequest getPostData)
        {
            return await _retrieving.GetPost(authData, getPostData);
        }
    }
}
