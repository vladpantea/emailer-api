using System;

namespace Emailer.API.Helpers
{
    public class Helper
    {
        public Helper(){}

        public decimal GetTimestamp()
        {   
            return (decimal)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}