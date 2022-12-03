using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSample.Notifications
{
    public class GmailAdapter : ISendMessage
    {
        GmailServiceGoogle gmailService = new GmailServiceGoogle();
        public void Send(string Text)
        {
            gmailService.SendMail(Text);
        }
    }


    //dll
    internal class GmailServiceGoogle
    {
        internal void SendMail(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine($"Send Message With GmailServiceGoogle dll ");
        }
    }
}
