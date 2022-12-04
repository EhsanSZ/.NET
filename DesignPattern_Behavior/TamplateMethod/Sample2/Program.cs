using System;

namespace Sample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client.RunTemplateMethod(new CocreteClass1());
            Console.WriteLine("---------------------------");
            Client.RunTemplateMethod(new ConcreteClass2());
        }
    }

    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.Hook1();
            this.BaseOperation1();
            this.RequiredOperation1();
            this.BaseOperation2();
            this.RequiredOperation2();
            this.Hook2();
        }


        protected void BaseOperation1()
        {
            Console.WriteLine("AbstractClass.BaseOperation1() Run....");
        }
        protected void BaseOperation2()
        {
            Console.WriteLine("AbstractClass.BaseOperation2() Run....");
        }

        //این متد نیاز به توسعه توسط در کلاس دارد
        protected abstract void RequiredOperation1();
        protected abstract void RequiredOperation2();

        protected virtual void Hook1() { }
        protected virtual void Hook2() { }
    }


    class CocreteClass1 : AbstractClass
    {
        protected override void RequiredOperation1()
        {
            Console.WriteLine(" ---> CocreteClass1.RequiredOperation1() Run....");
        }

        protected override void RequiredOperation2()
        {
            Console.WriteLine(" ---> CocreteClass1.RequiredOperation2() Run....");

        }

        protected override void Hook1()
        {
            Console.WriteLine(" ---> CocreteClass1.Hook1() Run....");
            base.Hook1();
        }
    }

    class ConcreteClass2 : AbstractClass
    {
        protected override void RequiredOperation1()
        {
            Console.WriteLine(" ---> CocreteClass2.RequiredOperation1() Run....");

        }
        protected override void RequiredOperation2()
        {
            Console.WriteLine(" ---> CocreteClass2.RequiredOperation2() Run....");
        }
    }


    class Client
    {
        public static void RunTemplateMethod(AbstractClass abstractClass)
        {
            abstractClass.TemplateMethod();
        }
    }
}
