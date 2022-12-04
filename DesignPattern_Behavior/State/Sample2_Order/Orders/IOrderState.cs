using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Orders
{
    /// <summary>
    /// State
    /// </summary>
    public interface IOrderState
    {
        bool CanSend(Order order);
        void Sent(Order order);
        bool CanCancel(Order order);
        void Cancel(Order order);
        bool CanDeliver(Order order);
        void Delivered(Order order);
        OrderStatus Status { get; }
    }

    
}
