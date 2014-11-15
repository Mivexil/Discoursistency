using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.CategoryRetrieving;
using Discoursistency.Base.Models.NotificationRetrieving;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.CategoryRetrieving
{
    public class BaseCategoryRetrievalService : IBaseCategoryRetrievalService
    {
        private IClient _client;
        public BaseCategoryRetrievalService(IClient client)
        {
            _client = client;
        }
        public async Task<CategoryListResponse> GetCategories(AuthenticationData authData)
        {
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
                Target = "/categories.json"
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<CategoryListResponse>();
        }
    }
}
