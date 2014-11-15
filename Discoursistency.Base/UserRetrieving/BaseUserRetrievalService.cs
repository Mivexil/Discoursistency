using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.UserRetrieving;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.UserRetrieving
{
    public class BaseUserRetrievalService : IBaseUserRetrievalService
    {
        private IClient _client;
        public BaseUserRetrievalService(IClient client)
        {
            _client = client;
        }
        public async Task<UserModel> GetUserData(AuthenticationData authData,
            UserRequest userData)
        {
            var targetURL = "/users/" + userData.username + ".json";
            userData.username = null;
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = userData,
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
            return response.Content.GetObject<UserModel>();
        }
    }
}
