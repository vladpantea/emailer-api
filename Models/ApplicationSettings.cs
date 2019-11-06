using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emailer.API.Models
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string Port { get; set; }
        public string Secret { get; set; }

        public string ServiceAudience { get; set; }

        public string IdentityIssuer { get; set; }
    }

    public interface IApplicationSettings
    {
        public string Port { get; set; }
        public string Secret { get; set; }

        public string ServiceAudience { get; set; }

        public string IdentityIssuer { get; set; }
    }
}
