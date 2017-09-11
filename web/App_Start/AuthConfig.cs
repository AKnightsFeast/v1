using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Microsoft.Web.WebPages.OAuth;

using web.Models;

namespace web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "184937635039454",
                appSecret: "0edc5fc3babb9835e999a75dd02998f2",
                displayName: "facebook"
            );

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
