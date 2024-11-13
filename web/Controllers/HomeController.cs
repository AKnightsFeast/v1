using System;
using System.Text;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json.Linq;

using web.Utilities;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        string PayPalSdkBaseUrl { get { return ConfigurationManager.AppSettings["PAYPAL_SDK_BASEURL"] ?? ""; } }

        string PayPalDomains { get { return ConfigurationManager.AppSettings["PAYPAL_DOMAINS"] ?? ""; } }

        public async Task<ActionResult> Index() {
            return View(new Dictionary<string, string> {
                {
                    "sdkSrc", GetPayPalSdkUrl()
                },
                {
                    "token", await GetClientTokenAsync()
                }
            });
        }

        string GetPayPalSdkUrl()
        {
            if (string.IsNullOrEmpty(Config.PayPalClientId)) throw new InvalidOperationException("Missing PAYPAL_CLIENT_ID");

            var sdkUrl = new UriBuilder(new Uri(new Uri(PayPalSdkBaseUrl), "/sdk/js"));
            sdkUrl.Query = "client-id=" + Config.PayPalClientId + "&components=buttons,fastlane";

            return sdkUrl.ToString();
        }

        async Task<string> GetClientTokenAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Config.PayPalApiBaseUrl + "/v1/oauth2/token");

                request.Headers.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(Config.PayPalClientId + ":" + Config.PayPalClientSecret))
                );

                request.Content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair <string, string> ("grant_type", "client_credentials"),
                    new KeyValuePair <string, string> ("response_type", "client_token"),
                    new KeyValuePair <string, string> ("intent", "sdk_init"),
                    new KeyValuePair <string, string> ("domains[]", PayPalDomains)
                });

                var response = await NonSSLHttpClient.SendRequest(request);
                response.EnsureSuccessStatusCode();

                var jsonDoc = JObject.Parse(await response.Content.ReadAsStringAsync());
                return jsonDoc.Root["access_token"]?.Value<string>() ?? "";
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return "";
            }
        }
    }
}