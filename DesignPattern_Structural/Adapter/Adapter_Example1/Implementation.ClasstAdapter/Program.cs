using System;

namespace Implementation.ClasstAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new Adapter();
            target.Operation();

        }
    }


    public interface ITarget
    {
        void Operation();
    }


    public class Adaptee
    {
        public void SpecificOperation()
        {
            Console.WriteLine("Adaptee.SpecificOperation()");
        }
    }


    public class Adapter : Adaptee, ITarget
    {
        public void Operation()
        {
            SpecificOperation();
        }
    }
}
