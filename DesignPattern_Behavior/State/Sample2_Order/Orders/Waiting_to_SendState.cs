using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Orders
{
    public class Waiting_to_SendState : IOrderState
    {
        public OrderStatus Status
        {
            get { return OrderStatus.Waiting_to_Send; }
        }

        public bool CanCancel(Order order)
        {
            return true;
        }

        public void Cancel(Order order)
        {

            //cancel
            Console.WriteLine("Sefaresh CANCEL Shod...");
            order.ChangeState(new CancelledState());
        }

        public bool CanDeliver(Order order)
        {
            return false;
        }

        public bool CanSend(Order order)
        {
            return true;
        }

        public void Delivered(Order order)
        {
            throw new NotImplementedException("ghabl az ersan nemitavan sefaresh ro tahvil dad");
        }

        public void Sent(Order order)
        {
            Console.WriteLine("Sefaresh Ersal Shod...");
            order.ChangeState(new SentState());
        }
    }
}
