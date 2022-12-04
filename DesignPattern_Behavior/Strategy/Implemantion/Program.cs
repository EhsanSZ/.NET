using System;

namespace Implemantion_Strategy1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context;
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());

            context.ContextInterface();


            context = new Context(new ConcreteStrategyC());

            context.ContextInterface();

            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Strategy
    {
        public abstract void AlgoritmInterface();
    }


    public class ConcreteStrategyA : Strategy
    {
        public override void AlgoritmInterface()
        {
            Console.WriteLine("ConcereteStrategyA.AlgoritmInterface()");
        }
    }


    public class ConcreteStrategyB : Strategy
    {
        public override void AlgoritmInterface()
        {
            Console.WriteLine("ConcereteStrategyB.AlgoritmInterface()");

        }
    }

    public class ConcreteStrategyC : Strategy
    {
        public override void AlgoritmInterface()
        {
            Console.WriteLine("ConcereteStrategyC.AlgoritmInterface()");
        }
    }


    public class Context
    {
        private Strategy strategy;
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgoritmInterface();
        }
    }
}
