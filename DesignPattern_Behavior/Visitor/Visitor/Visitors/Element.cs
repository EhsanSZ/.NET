using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Visitors
{
    public abstract class Element
    {
        public abstract void Accept(ConcreteVisitor1 visitor);
    }

    public class ConcreteElementA : Element
    {
        public string Name { get; private set; }
        public ConcreteElementA(string name)
        {
            this.Name = name;
        }

        public override void Accept(ConcreteVisitor1 visitor)
        {
            visitor.Visit(this);
        }
    }

    public class TaxiOrder : Element
    {
        public override void Accept(ConcreteVisitor1 visitor)
        {
            visitor.Visit(this);
        }
    }


    public class FoodOrder : Element
    {
        public override void Accept(ConcreteVisitor1 visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ConcreteElementB : Element
    {
        public string OrderId { get; private set; }

        public ConcreteElementB(string orderid)
        {
            this.OrderId = orderid;
        }
        public override void Accept(ConcreteVisitor1 visitor)
        {
            visitor.Visit(this);
        }
    }

}
