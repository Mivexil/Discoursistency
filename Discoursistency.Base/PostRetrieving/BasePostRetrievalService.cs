using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.NotificationRetrieving;
using Discoursistency.Base.Models.PostRetrieving;
using Discoursistency.Base.Models.UserActionRetrieving;
using Discoursistency.Base.Models.UserRetrieving;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.PostRetrieving
{
    public class BasePostRetrievalService : IBasePostRetrievalService
    {
        private IClient _client;

        public BasePostRetrievalService(IClient client)
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
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
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
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<MultiplePostsModel>();
        }

        public async Task<string> GetRawPost(AuthenticationData authData, GetPostByTopicRequest postData)
        {
            var targetURL = "/raw/" + postData.topic_id + "/" + postData.post_id;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = null,
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
            if (response.Type != ResponseType.Text)
                throw new UnsupportedTypeException(response.Type, ResponseType.Text);
            return response.Content.StringContent;
        }

        public async Task<TopicModel> GetTopic(AuthenticationData authData, TopicRequest requestData)
        {
            var targetURL = "/t/" + requestData.topic_id + ".json";
            requestData.topic_id = null;
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
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<TopicModel>();
        }

        public async Task<TopicListResponse> GetLatest(AuthenticationData authData, TopicListRequest requestData)
        {
            var targetURL = (requestData.category_name != null ? String.Format("/c/{0}/l", requestData.category_name) : "") + "/latest.json";
            requestData.category_name = null;
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
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<TopicListResponse>();
        }

        public async Task<TopicListResponse> GetNew(AuthenticationData authData, TopicListRequest requestData)
        {
            var targetURL = (requestData.category_name != null ? String.Format("/c/{0}/l", requestData.category_name) : "") + "/new.json";
            requestData.category_name = null;
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
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<TopicListResponse>();
        }

        public async Task<TopicListResponse> GetUnread(AuthenticationData authData, TopicListRequest requestData)
        {
            var targetURL = (requestData.category_name != null ? String.Format("/c/{0}/l", requestData.category_name) : "") + "/unread.json";
            requestData.category_name = null;
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
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<TopicListResponse>();
        }
    }
}
