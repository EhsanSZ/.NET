using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator_Console
{
    public abstract class Component
    {
        public abstract void operation();
        public abstract void operation2();
    }

    public class ConcreteComponent : Component
    {
        public override void operation()
        {
            Console.WriteLine("ConcreteComponent.operation() run.....!");
        }

        public override void operation2()
        {
            throw new NotImplementedException();
 
        }
    }
}
