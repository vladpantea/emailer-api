using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emailer.API.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        public string Verify(string token)
        {
            throw new NotImplementedException();
        }
    }

    public interface IJwtHelper
    {
        public string Verify(string token);
    }
}
