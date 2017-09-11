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
    }
}