using System;

namespace Decorator_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcreteComponent concrete = new ConcreteComponent();

            //concrete.operation();
            ConcreateDecorator concreateDecorator = new ConcreateDecorator(concrete);
            concreateDecorator.operation();

            
            SendEmail_Example2 sendEmail = new SendEmail_Example2();
            //sendEmail.Send();

            SendEmailDecorator sendEmailDecorator = new SendEmailDecorator(sendEmail);
            sendEmail.Send();
            Console.ReadLine();
        }
    }
}
