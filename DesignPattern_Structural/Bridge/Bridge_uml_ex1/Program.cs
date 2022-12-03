using Bridge_uml_ex1.Bridge.Abstractions;
using System;

namespace Bridge_uml_ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Abstraction abstraction = new RefinedAbstraction();

            abstraction.Function();

            Console.ReadKey();
        }
    }
}
