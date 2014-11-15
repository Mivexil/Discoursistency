using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.Base.Exceptions;
using Discoursistency.Base.Models.Authentication;
using Discoursistency.Base.Models.MessageBus;
using Discoursistency.HTTP.Client;
using Discoursistency.HTTP.Client.Models;

namespace Discoursistency.Base.MessageBus
{
    public class BaseMessageBusService : IBaseMessageBusService
    {
        private IClient _client;

        public BaseMessageBusService(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<MessageBusResponse>> PollMessageBus(AuthenticationData authData, MessageBusRequest msgData)
        {
            var targetURL = "/message-bus/" + msgData.busID + "/poll" + (msgData.dlp == true ? "?dlp=t" : "");
            var request = new HTTPClientRequest
            {
                AsXmlHttpRequest = true,
                Content = msgData.channels,
                Headers = new AuthData
                {
                    CookieString = authData.Cookie,
                    XSRFString = authData.CSRFToken
                },
                Method = HttpMethod.Post,
                Target = targetURL
            };
            var response = await _client.IssueRequest(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new StatusCodeException((int)response.StatusCode, response.Content);
            if (response.Type != ResponseType.JSON)
                throw new UnsupportedTypeException(response.Type, ResponseType.JSON);
            return response.Content.GetObject<IEnumerable<MessageBusResponse>>();
        }
    }
}
