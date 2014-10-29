using System;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;
using Microsoft.CSharp.RuntimeBinder;

namespace Discoursistency.Base.Authentication
{
    public class DiscourseAuthenticationService : IDiscourseAuthenticationService
    {
        private IClient _client;

        public DiscourseAuthenticationService(IClient client)
        {
            _client = client;
        }

        public async Task<AuthenticationData> GetCSRFToken(AuthenticationData incomingData)
        {
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = null,
                Headers = new AuthData
                {
                    CookieString = incomingData.Cookie,
                    XSRFString = null
                },
                Method = HttpMethod.Get,
                Target = "/session/csrf"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK) 
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            if (response.Type != ResponseType.JSON) 
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            var csrfObject = CSRFResponse.FromDynamic(response.Content.GetObject());
            return new AuthenticationData
            {
                Cookie = incomingData.Cookie,
                CSRFToken = csrfObject.csrf
            };
        }

        public async Task<AuthenticationData> Login(AuthenticationData incomingData, LoginRequestData loginData)
        {
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = loginData,
                Headers = new AuthData
                {
                    CookieString = incomingData.Cookie,
                    XSRFString = incomingData.CSRFToken
                },
                Method = HttpMethod.Post,
                Target = "/session"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK) 
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            if (response.CookieString == null)
                throw new CookieNotReceivedException();
            return new AuthenticationData
            {
                Cookie = response.CookieString,
                CSRFToken = incomingData.CSRFToken
            };
        }
    }
}
