using System;


namespace Bridge_uml_ex1.Bridge.Implementors
{
    public abstract class Implementor
    {
        public abstract void Implementaion();
    }

    public class ConcreateImplementor: Implementor
    {
        public override void Implementaion()
        {
            Console.WriteLine("Run   ConcreateImplementor.Implementaion()....");
        }
    }
}
