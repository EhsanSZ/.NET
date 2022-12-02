using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2_FactoryMehod.Sms.Kavenegar
{
    public class KavenegarSmsManager : ISmsManager
    {
        public List<SmsDto> GetList()
        {
            List<SmsDto> sms = new List<SmsDto>();
            return sms;
        }

        public void Send(SmsDto sms)
        {
            Console.WriteLine("Send Sms  With KavenegarSmsManager..........");
            //send sms;

        }
    }
}
