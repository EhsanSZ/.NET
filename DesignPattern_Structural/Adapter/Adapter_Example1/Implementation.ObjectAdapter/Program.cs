using System;

namespace Implementation.ObjectAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Operation();
            Console.ReadLine();
        }
    }


    public abstract class Target
    {
        public abstract void Operation();
    }

    public class Adaptee
    {
        public void SpecificOperation()
        {
            Console.WriteLine("Adaptee.SpecificOperation()");
        }
    }

    public class Adapter : Target
    {
        private Adaptee adaptee;
        public Adapter()
        {
            adaptee = new Adaptee();
        }
        public override void Operation()
        {
            adaptee.SpecificOperation();
        }
    }
}
