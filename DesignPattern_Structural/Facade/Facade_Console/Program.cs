using System;

namespace Facade_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.doSomething();
            Console.ReadLine();
        }
    }
}
