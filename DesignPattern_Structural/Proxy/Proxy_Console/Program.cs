using System;

namespace Proxy_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISubject subject = new Proxy();
            if (1 == 1)
            {

            }
            subject.DoAction();

            Console.WriteLine("Hello World!");
        }

        public interface ISubject
        {
            void DoAction();
        }

        internal class RealSubject : ISubject
        {
            public void DoAction()
            {
                Console.WriteLine("RealSubject.DoAction() is Run....");
            }
        }


        public class Proxy : ISubject
        {
            private RealSubject RealSubject;

            public void DoAction()
            {
                if (RealSubject == null)
                {
                    RealSubject = new RealSubject();
                }
                RealSubject.DoAction();
            }
        }
    }


}
