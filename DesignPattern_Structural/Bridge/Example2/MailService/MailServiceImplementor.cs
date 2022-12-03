using System;

namespace Example2.MailService
{
    public interface IMailServiceImplementor
    {
        void SendEmail(string Reciver, string Title, string Message);
    }

    public class GmailService : IMailServiceImplementor
    {
        public void SendEmail(string Reciver, string Title, string Message)
        {
            //کدهای ارسال ایمیل
            Console.WriteLine($"Email --{Title}-- Sended to --{Reciver}--  With   **{nameof(GmailService)}**");
        }
    }

    public class YahooService : IMailServiceImplementor
    {
        public void SendEmail(string Reciver, string Title, string Message)
        {
            //کدهای ارسال ایمیل
            Console.WriteLine($"Email --{Title}-- Sended to --{Reciver}-- With    **{nameof(YahooService)}**");
        }
    }


    public class MyCompanyMailService : IMailServiceImplementor
    {
        public void SendEmail(string Reciver, string Title, string Message)
        {
            //کدهای ارسال ایمیل
            Console.WriteLine($"Email --{Title}-- Sended to --{Reciver}-- With    **{nameof(MyCompanyMailService)}**");
        }
    }
}

