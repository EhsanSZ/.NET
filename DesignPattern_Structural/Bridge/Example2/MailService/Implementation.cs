using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.MailService
{
    public static class Implementation
    {
        public static IMailServiceImplementor GetImplementor()
        {
            //string service = "yahoo";
            //if (service == "gmail")
            //{
            //    return new GmailService();
            //}
            //else if (service == "yahoo")
            //{
            //    return new YahooService();
            //}
            //return new MyCompanyMailService();

            var config = ConfigurationManager.AppSettings;
            if(config["EmailImplementor"]=="Gmail")
            {
                return new GmailService();
            }
            else if (config["EmailImplementor"] == "Yahoo")
            {
                return new YahooService();
            }
            else
            {
                return new MyCompanyMailService();
            }
        }
    }
}

