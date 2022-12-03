using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator_Console
{
    //مثال دوم به ساده ترین حالت
    public class SendEmail_Example2
    {
        public void Send()
        {
            Console.WriteLine("Email Sended......!");
        }
    }
    public class SendEmailDecorator:SendEmail_Example2
    {
        private readonly SendEmail_Example2 _sendEmail;
        public SendEmailDecorator(SendEmail_Example2 sendEmail)
        {
            _sendEmail = sendEmail;
        }

        public void Send()
        {
            _sendEmail.Send();
            Savelog();
        }

        private void Savelog()
        {
            Console.WriteLine("Savelog  ......!");
        }
    }
}
