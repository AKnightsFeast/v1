using System;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

using web.Models;
using web.Models.Enums;
using web.Utilities;

namespace web.Controllers.api
{
    public class PaymentController : ApiController
    {
        // POST: api/Payment
        public async Task<HttpStatusCodeResult> Post([FromBody]OrderRequest order)
        {
            try {
                var accessToken = await GenerateAccessToken();
                var url = Config.PayPalApiBaseUrl + "/v2/checkout/orders";

                var fullName = order?.ShippingAddress?.Name?.FullName;
                var countryCode = order?.ShippingAddress?.PhoneNumber?.CountryCode;
                var nationalNumber = order?.ShippingAddress?.PhoneNumber?.NationalNumber;

                var payload = new {
                    intent = "CAPTURE",
                        payment_source = new {
                            card = new {
                                single_use_token = order?.PaymentToken?.Id
                            }
                        },
                        purchase_units = new [] {
                        new {
                            amount = new {
                                currency_code = "USD",
                                value = order.OrderType == MealsServiceType.MealsService ? "625" : "475"
                            },
                            shipping = order?.ShippingAddress == null ? null : new {
                                type = "SHIPPING",
                                name = !string.IsNullOrEmpty(fullName) ? new {
                                    full_name = fullName
                                } : null,
                                address = new {
                                    address_line_1 = order.ShippingAddress.Address?.Address1,
                                    address_line_2 = order.ShippingAddress.Address?.Address2,
                                    postal_code = order.ShippingAddress.Address?.ZipCode,
                                    country_code = order.ShippingAddress.Address?.CountryCode
                                },
                                phone_number = !string.IsNullOrEmpty(countryCode) && !string.IsNullOrEmpty(nationalNumber) ? new {
                                    country_code = countryCode,
                                    national_number = nationalNumber
                                } : null
                            }
                        }   
                    }
                }; 

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                request.Headers.Add("PayPal-Request-Id", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
                request.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                var response = await NonSSLHttpClient.SendRequest(request);

                return new HttpStatusCodeResult(response.StatusCode, JObject.Parse(await response.Content.ReadAsStringAsync()).Root.ToString());
            }
            catch (Exception ex) {
                Console.WriteLine(ex);

                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        async Task<string> GenerateAccessToken()
        {
            if (string.IsNullOrEmpty(Config.PayPalClientId) || string.IsNullOrEmpty(Config.PayPalClientSecret))
                throw new Exception("Missing API credentials");

            var url = Config.PayPalApiBaseUrl + "/v1/oauth2/token";
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(Config.PayPalClientId + ":" + Config.PayPalClientSecret));

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);
            request.Content = new FormUrlEncodedContent(new[] {
                new KeyValuePair < string, string > ("grant_type", "client_credentials")
            });

            var response = await NonSSLHttpClient.SendRequest(request);
            response.EnsureSuccessStatusCode();

            var jsonDoc = JObject.Parse(await response.Content.ReadAsStringAsync());
            return jsonDoc.Root.Value<string>("access_token") ?? "";
        }
    }
}