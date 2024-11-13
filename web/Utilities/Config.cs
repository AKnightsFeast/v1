using System;
using System.Configuration;

namespace web.Utilities
{
    public static class Config
    {
        public static int MinRequiredPasswordLength
        {
            get
            {
                var minPwdLength = 0;

                int.TryParse(ConfigurationManager.AppSettings["MinRequiredPasswordLength"], out minPwdLength);

                return minPwdLength;
            }
        }

        public static string PayPalClientId
        {
            get { return ConfigurationManager.AppSettings["PAYPAL_CLIENT_ID"] ?? ""; }
        }

        public static string PayPalClientSecret
        {
            get { return ConfigurationManager.AppSettings["PAYPAL_CLIENT_SECRET"] ?? ""; }
        }

        public static string PayPalApiBaseUrl
        {
            get { return ConfigurationManager.AppSettings["PAYPAL_API_BASEURL"] ?? ""; }
        }
    }
}