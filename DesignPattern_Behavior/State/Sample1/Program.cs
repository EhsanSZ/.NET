using System;

namespace Sample1_State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                Context context = new Context();
                context.Request();
                context.Request();
                context.Request();
                Console.Read();
            }
        }

        public abstract class State
        {
            public abstract void Handle(Context context);
        }

        public class Context
        {
            public State State { get; set; }
            public Context()
            {
                State = new ConcreteStateA();
            }

            public void Request()
            {
                State.Handle(this);
            }
        }

        public class ConcreteStateA : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("Request Handle by ConcreteStateA");
                context.State = new ConcreteStateB();
            }
        }

        public class ConcreteStateB : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("Request Handle by ConcreteStateB");
                context.State = new ConcreteStateC();
            }
        }

        public class ConcreteStateC : State
        {
            public override void Handle(Context context)
            {
                Console.WriteLine("Request Handle by ConcreteStateC");
                context.State = new ConcreteStateA();

            }
        }
    }
}
