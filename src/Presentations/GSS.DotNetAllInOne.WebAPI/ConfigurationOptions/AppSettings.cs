using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSS.DotNetAllInOne.WebAPI.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public string AllowedHosts { get; set; }

        public CORS CORS { get; set; }
    }
}
