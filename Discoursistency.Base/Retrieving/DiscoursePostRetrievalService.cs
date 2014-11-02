using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Retrieving;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.Retrieving
{
    public class DiscoursePostRetrievalService : IDiscoursePostRetrievalService
    {
        private IClient _client;

        public DiscoursePostRetrievalService(IClient client)
        {
            _client = client;
        }

        public async Task<PostModel> GetPost(AuthenticationData authData, GetPostRequest getPostData)
        {
            var targetURL = "/posts/" + getPostData.id + ".json";
            getPostData.id = null;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = getPostData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Get,
                Target = targetURL
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            return response.Content.GetObject<PostModel>();
        }

        public async Task<MultiplePostsModel> GetMultiplePosts(AuthenticationData authData,
            GetMultiplePostsRequest requestData)
        {
            var targetURL = "/t/" + requestData.topicId + "/posts.json";
            requestData.topicId = null;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = requestData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Get,
                Target = targetURL
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            return response.Content.GetObject<MultiplePostsModel>();
        }
    }
}
