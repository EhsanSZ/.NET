using System;

namespace Sample1_TamplateMehod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client.Run(new ConcreteClass());
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class AbstractClass
    {

        public void TemplateMethod()
        {
            Console.WriteLine("==========>>AbstractClass.TemplateMethod()  Start");
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("---------->>AbstractClass.TemplateMethod()  End");
        }

        protected abstract void PrimitiveOperation1();
        protected abstract void PrimitiveOperation2();
    }

    public class ConcreteClass : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClass.PrimitiveOperation1()");

        }

        protected override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClass.PrimitiveOperation2()");
        }
    }


    public class Client
    {

        public static void Run(AbstractClass abstractClass)
        {
            abstractClass.TemplateMethod();
        }
    }
}
