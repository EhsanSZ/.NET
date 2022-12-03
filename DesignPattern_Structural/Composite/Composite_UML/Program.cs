using Composite_UML.CompositeClass;
using System;
using Component = Composite_UML.CompositeClass.Component;

namespace Composite_UML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Component component = new Composite
                ("Root Item", new Component[]
                    {
                    new Leaf("Leaf 1"),
                    new Composite ("Composite 1",new Component[]
                    {
                        new Leaf("Leaf 1-1"),
                        new Leaf("Leaf 1-2"),
                        new Composite("Composite 1-1",new Component[]
                        {
                            new Leaf("Laef 1-1-1-"),
                            new Composite("empty Composite",new Component[]{ }),
                        })
                    }),
                    new Leaf("Leaf 2"),
                    new Leaf("Leaf 3"),
                    new Leaf("Leaf 4"),
                    });
            component.Display(1);

        }
    }
}
