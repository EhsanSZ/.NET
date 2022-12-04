using System;

namespace Sample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Handler handler1 = new ConcreteHandler1();
            Handler handler2 = new ConcreteHandler2();

            handler1.SetSuccessor(handler2);

            handler1.HandleRequest(10);
            handler1.HandleRequest(1000);

            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Handler
    {
        protected Handler successor;
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }
        public abstract void HandleRequest(int request);
    }

    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request < 50)
            {
                Console.WriteLine($"ConcreteHandler1 {request}....");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }

        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 50)
            {
                Console.WriteLine($"ConcreteHandler2 {request}....");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
