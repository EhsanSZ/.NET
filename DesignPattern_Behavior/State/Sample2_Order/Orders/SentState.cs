using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Orders
{
    public class SentState : IOrderState
    {
        public OrderStatus Status => OrderStatus.Sent;

        public bool CanCancel(Order order)
        {
            return true;
        }

        public void Cancel(Order order)
        {
            Console.WriteLine("Sefaresh Cancel Shod....!");
            order.ChangeState(new CancelledState());
        }

        public bool CanDeliver(Order order)
        {
            return true;
        }

        public bool CanSend(Order order)
        {
            return false;
        }

        public void Delivered(Order order)
        {
            Console.WriteLine("Sefaresh tahvil Shod....!");
            order.ChangeState(new DeliveredState());
        }

        public void Sent(Order order)
        {
            throw new NotImplementedException("sefaresh dar hal ersal mibashad");

        }
    }
}
