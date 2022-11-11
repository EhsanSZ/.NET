using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class SmsService
    {
        public void Send(string PhoneNumber,string Code)
        {
            var client = new WebClient();
            string url = $"http://panel.kavenegar.com/v1/apikey/verify/lookup.json?receptor={PhoneNumber}&token={Code}&template=VerifyBugetoAccount";
            var content= client.DownloadString(url);
        }
    }
}
