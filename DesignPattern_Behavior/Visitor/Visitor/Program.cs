using System;
using Visitor.Visitors;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiOrder order1 = new TaxiOrder();
            FoodOrder foodorder1 = new FoodOrder();

            ConcreteElementA a1 = new ConcreteElementA("A1");
            ConcreteElementA a2 = new ConcreteElementA("A2");
            ConcreteElementA a3 = new ConcreteElementA("A3");
            ConcreteElementA a4 = new ConcreteElementA("A4");
            ConcreteElementA a5 = new ConcreteElementA("A5");

            ConcreteElementB b1 = new ConcreteElementB("123654");
            ConcreteElementB b2 = new ConcreteElementB("5674");
            ConcreteElementB b3 = new ConcreteElementB("876");
            ConcreteElementB b4 = new ConcreteElementB("124");

            ObjectStructure objectStructure = new ObjectStructure();
            objectStructure.Add(order1);
            objectStructure.Add(foodorder1);

            objectStructure.Add(a1);
            objectStructure.Add(a2);
            objectStructure.Add(a3);
            objectStructure.Add(b2);
            objectStructure.Add(b3);
            objectStructure.Add(a4);
            objectStructure.Add(a5);
            objectStructure.Add(b1);
            objectStructure.Add(b4);
            var visitor = new ConcreteVisitor1();
            objectStructure.Accept(visitor);

            Console.Read();
            Console.WriteLine("Hello World!");
        }
    }
}
