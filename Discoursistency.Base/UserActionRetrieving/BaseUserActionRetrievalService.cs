using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.UserActionRetrieving;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.UserActionRetrieving
{
    public class BaseUserActionRetrievalService : IBaseUserActionRetrievalService
    {
        private IClient _client;
        public BaseUserActionRetrievalService(IClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<UserActionModel>> GetUserActions(AuthenticationData authData, UserActionRequest actionData)
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
                Method = HttpMethod.Get,
                Target = "/user_actions.json"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<IEnumerable<UserActionModel>>();
        }
    }
}
