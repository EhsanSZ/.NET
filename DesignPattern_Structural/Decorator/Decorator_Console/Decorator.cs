using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator_Console
{
    public abstract class Decorator:Component 
    {
        private readonly Component _component;
        public Decorator(Component component)
        {
            _component = component;
        }

        public override void operation()
        {
            _component.operation();

        }

        public override void operation2()
        {
            _component.operation2();
        }
    }

    public class ConcreateDecorator: Decorator
    {

        public ConcreateDecorator(Component component) : base (component)
        {

        }

        public override void operation()
        {
            base.operation();
            NewFeature();
        }

        public override void operation2()
        {
            base.operation2();
        }

        public void NewFeature()
        {
            Console.WriteLine("This is Write at NewFeature()");
        }
    }


    public class ConcreateDecorator2 : Decorator
    {

        public ConcreateDecorator2(Component component) : base(component)
        {

        }

        public override void operation()
        {
            base.operation();
            NewFeature();
        }


        public void NewFeature()
        {
            Console.WriteLine("  NewFeature() 2 ");
        }
    }
    public class NewDecorator: Decorator
    {

        public NewDecorator(Component component) : base(component)
        {
            // رفتار جدیدی یا ویژگی جدید
        }
        public override void operation()
        {
            base.operation();
        }
    }
}
