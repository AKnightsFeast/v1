using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace web.Utilities
{
    public static class NonSSLHttpClient
    {
        static readonly HttpClient _httpClient;

        static NonSSLHttpClient()
        {
            if (_httpClient == null)
            {
                var handler = new WebRequestHandler()
                {
                    ServerCertificateValidationCallback = delegate { return true; },
                    ServerCertificateCustomValidationCallback = delegate { return true; },
                };

                _httpClient = new HttpClient(handler);
            }
        }

        public static async Task<HttpResponseMessage> SendRequest(HttpRequestMessage request)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = 9999;

            return await _httpClient.SendAsync(request);
        }
    }
}