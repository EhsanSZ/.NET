using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Orders
{
    public class DeliveredState : IOrderState
    {
        public OrderStatus Status => OrderStatus.Delivered;

        public bool CanCancel(Order order)
        {
            return false;
        }

        public void Cancel(Order order)
        {
            throw new NotImplementedException("Sefaresh tahvil shode ra nemitavan CANCEL kard.");

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
            throw new NotImplementedException("sefaresh ghablan tahvil dade shode ast....");

        }

        public void Sent(Order order)
        {
            throw new NotImplementedException("sefaresh tahvil dade shode ast... nemitavan dobare ersal kard.");
        }
    }
}
