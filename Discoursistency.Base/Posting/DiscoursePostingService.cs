using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.Posting;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.Posting
{
    public class DiscoursePostingService : IDiscoursePostingService
    {
        private IClient _client;

        public DiscoursePostingService(IClient client)
        {
            _client = client;
        }

        public async Task CreatePost(AuthenticationData authData, PostRequest postData)
        {
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = postData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Post,
                Target = "/posts"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
        }

        public async Task PerformPostAction(AuthenticationData authData, PostActionRequest actionData)
        {
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = actionData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Post,
                Target = "/post_actions"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
        }

        public async Task DeletePostAction(AuthenticationData authData, PostActionRequest actionData)
        {
            var targetURL = "/post_actions/" + actionData.id;
            actionData.id = null;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = actionData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Delete,
                Target = targetURL
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
        }

        public async Task Timings(AuthenticationData authData, TimingsRequest timings)
        {
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = timings,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Delete,
                Target = "/timings"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
        }

        public async Task EditPost(AuthenticationData authData, PostEditRequest editData)
        {
            var targetURL = "/posts/" + editData.id;
            editData.id = null;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = editData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Put,
                Target = targetURL
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
        
        }

        public async Task DeletePost(AuthenticationData authData, PostDeleteRequest deleteData)
        {
            var targetURL = "/posts/" + deleteData.id;
            deleteData.id = null;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = deleteData,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Delete,
                Target = targetURL
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
        
        }
    }
}
