using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jls.Tools.Testing.MoapiClient.Configuration;

namespace Jls.Tools.Testing.MoapiUI.Configuration
{
    public class AppConfigSettings : IMoapiSettings
    {
        public string MapSourceA => ConfigurationManager.AppSettings["MapSource.A"];

        public string MapSourceB => ConfigurationManager.AppSettings["MapSource.B"];
        public string ApiKey => ConfigurationManager.AppSettings["API_KEY"];
        public string AppKey => ConfigurationManager.AppSettings["APP_KEY"];

        public int MaxResults => int.Parse(ConfigurationManager.AppSettings["MaxResults"]);

        public string DefaultCriteria => ConfigurationManager.AppSettings["DefaultCriteria"];

    }
}
