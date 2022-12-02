using System;
using Sample2_FactoryMehod.Sms;
using Sample2_FactoryMehod.Sms.FactoryMethod;

namespace Sample2_FactoryMehod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISmsManager sms;
            ICreator creator = new Creator();
            sms = creator.FacatoryMethod();
            sms.Send(new SmsDto
            {
                Message = "test",
                Reciver = "0912000000",
            });
        }
    }
}
