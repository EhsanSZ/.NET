using Example2.MailService;
using System;

namespace Example2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RefinedMailService mailService = new RefinedMailService();
            mailService.Send(new EmailInformationDto
            {
                Message = "this is a message from my app ",
                Reciver = "Ehsansz.ir",
                Title = "Alert mail"
            });
        }
    }
}
