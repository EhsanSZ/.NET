using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Visitors
{
    //public abstract class Visitor
    //{
    //    public abstract void VisitConcreteElementA(ConcreteElementA element);
    //    public abstract void VisitConcreteElementB(ConcreteElementB element);
    //    public abstract void VisitTaxiOrder(TaxiOrder taxiOrder);
    //    public abstract void VisitFoodOrder(FoodOrder foodOrder);
    //}

    public class ConcreteVisitor1 /*: Visitor*/
    {
        public  void Visit(ConcreteElementA element)
        {
            Console.WriteLine($"Type:{element.GetType().Name}  Name:{element.Name}  Visitor:{this.GetType().Name}");
        }

        public  void Visit(ConcreteElementB element)
        {
            Console.WriteLine($"Type:{element.GetType().Name}  OrderId:{element.OrderId}  Visitor:{this.GetType().Name}");
        }

        public  void Visit(FoodOrder foodOrder)
        {
            Console.WriteLine($"Type:{foodOrder.GetType().Name}     Visitor:{this.GetType().Name}");
        }

        public  void Visit(TaxiOrder taxiOrder)
        {
            Console.WriteLine($"Type:{taxiOrder.GetType().Name}     Visitor:{this.GetType().Name}");

        }
    }
}
