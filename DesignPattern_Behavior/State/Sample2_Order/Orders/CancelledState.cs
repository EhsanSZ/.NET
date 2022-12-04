using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Orders
{
    public class CancelledState : IOrderState
    {
        public OrderStatus Status =>  OrderStatus.Cancelled;

        public bool CanCancel(Order order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new NotImplementedException("sefarsh dar hal hazer dar state cancel mibashad");

        }

        public bool CanDeliver(Order order)
        {
            return false;

        }

        public bool CanSend(Order order)
        {
            return false;

        }

        public void Delivered(Order order)
        {
            throw new NotImplementedException("sefareshhaye cancel shode Ra, nemitavantahvil dad");

        }

        public void Sent(Order order)
        {
            throw new NotImplementedException("sefareshhaye cancel shode Ra, nemitavan ersal kard");

        }
    }
}
