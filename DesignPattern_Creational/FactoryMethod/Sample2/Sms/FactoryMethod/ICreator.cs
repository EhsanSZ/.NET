using Sample2_FactoryMehod.Sms.Kavenegar;
using Sample2_FactoryMehod.Sms.Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2_FactoryMehod.Sms.FactoryMethod
{
    public interface ICreator
    {
        ISmsManager FacatoryMethod();
    }

    public class Creator : ICreator
    {
        public ISmsManager FacatoryMethod()
        {
            string config = "Kavenegar";

            if (config == "Twilio")
            {
                return new TwilioSmsManager();
            }
            else
            {
                return new KavenegarSmsManager();
            }
        }
    }
}
