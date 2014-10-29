using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Discoursistency.HTTP.Client.Models;
using System.Web.Helpers;
using Discoursistency.Util.QueryStringCreator;

namespace Discoursistency.HTTP.Client
{
    public class Client : IClient
    {
        private readonly HttpClient _client;
        private readonly List<long> _requestList = new List<long>();
        private readonly int _requestsPerSecond;
        private async Task RateLimit()
        {
            while (true)
            {
                var currentTimestamp = DateTime.UtcNow.Ticks;
                long difference;
                lock (_requestList)
                {
                    if (_requestList.Count < _requestsPerSecond)
                    {
                        _requestList.Add(currentTimestamp);
                        return;
                    }
                    else
                    {
                        var minTimestamp = _requestList.Min();
                        difference = currentTimestamp - minTimestamp;
                        if (difference >= TimeSpan.TicksPerSecond)
                        {
                            _requestList.Remove(minTimestamp);
                            _requestList.Add(currentTimestamp);
                            return;
                        }
                    }
                }
                await Task.Delay(new TimeSpan(TimeSpan.TicksPerSecond - difference));
            }
            
        }

        public Client(string baseURL, int requestsPerSecond = 5)
        {
            _requestsPerSecond = requestsPerSecond;
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;   
            }
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(baseURL);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.01));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Discoursistency", "0.1"));
            _client.DefaultRequestHeaders.Connection.Add("keep-alive");
            _client.DefaultRequestHeaders.Host = baseURL.Replace("https://", "").Replace("http://", "");
        }

        public async Task<HTTPClientResponse> IssueRequest(HTTPClientRequest request)
        {
            if (request.Method != HttpMethod.Delete &&
                request.Method != HttpMethod.Get &&
                request.Method != HttpMethod.Post &&
                request.Method != HttpMethod.Put)
            {
                throw new NotSupportedException("Specified method: " + request.Method.Method + " is not supported. Supported methods include DELETE, GET, POST and PUT.");
            }
            string targetWithParameters = request.Target;
            if (request.Method == HttpMethod.Get && request.Content != null)
            {
                targetWithParameters = request.Target + "?" +
                                       QueryStringCreator.ToQueryParameters(request.Content);
            }
            using (var requestMessage = new HttpRequestMessage(request.Method, targetWithParameters))
            {
                if (request.Headers.CookieString != null) { requestMessage.Headers.Add("Cookie", request.Headers.CookieString); }
                if (request.Headers.XSRFString != null) { requestMessage.Headers.Add("X-CSRF-Token", request.Headers.XSRFString); }
                if (request.AsXmlHttpRequest) { requestMessage.Headers.Add("X-Requested-With", "XmlHttpRequest"); }
                if (request.Method != HttpMethod.Get && request.Content != null)
                {
                    requestMessage.Content = new StringContent(QueryStringCreator.ToQueryParameters(request.Content),
                        Encoding.UTF8,
                        "application/x-www-form-urlencoded");
                }
                await RateLimit();
                using (var rawResponse = await _client.SendAsync(requestMessage))
                {
                    var response = new HTTPClientResponse
                    {
                        StatusCode = rawResponse.StatusCode,
                        Success = rawResponse.IsSuccessStatusCode
                    };
                    IEnumerable<string> cookieStrings;
                    if (rawResponse.Headers.TryGetValues("Set-Cookie", out cookieStrings))
                    {
                        response.CookieString = cookieStrings.FirstOrDefault();
                    }
                    if (rawResponse.Content.Headers.Contains("Content-Type"))
                    {
                        var responseType = rawResponse.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                        if (responseType.Contains("application/json"))
                        {
                            var reply = await rawResponse.Content.ReadAsStringAsync();
                            try
                            {
                                response.Type = ResponseType.JSON;
                                response.Content = HTTPClientContent.FromObject(Json.Decode(reply));
                            }
                            catch (ArgumentException)
                            {
                                response.Type = ResponseType.MalformedJSON;
                                response.Content = reply;
                            }

                        }
                        else if (responseType.Contains("text/html"))
                        {
                            response.Type = ResponseType.HTML;
                            response.Content = await rawResponse.Content.ReadAsStringAsync();
                        }
                        else if (responseType.Contains("text/plain"))
                        {
                            response.Type = ResponseType.Text;
                            response.Content = await rawResponse.Content.ReadAsStringAsync();
                        }
                        else if (responseType.Contains("text/"))
                        {
                            response.Type = ResponseType.UnknownText;
                            response.Content = await rawResponse.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            response.Type = ResponseType.Unknown;
                            response.Content = await rawResponse.Content.ReadAsByteArrayAsync();
                        }
                    }
                    else
                    {
                        var innerContent = await rawResponse.Content.ReadAsByteArrayAsync();
                        if (innerContent.Length == 0)
                        {
                            response.Type = ResponseType.Empty;
                            response.Content = HTTPClientContent.FromObject(null);
                        }
                        response.Type = ResponseType.Unknown;
                        response.Content = await rawResponse.Content.ReadAsByteArrayAsync();
                    }
                    return response;
                }
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
