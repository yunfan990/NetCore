using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BT.Common.Helper
{
    public class ConfigureHelper
    {
        public IConfiguration Configuration;
        public ConfigureHelper(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public string GetSessionName()
        {
            return Configuration.GetConnectionString("SessionName");
        }
    }

    public class ConfigurationService
    {
        public static string GetConfigValue(string key)
        {
            var val = ConfigurationManager.AppSettings.Get(key);
            if (val != null)
            {
                return val;
            }
            return "";
        }
    }
}
