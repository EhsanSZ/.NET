using System;
using State.Orders;

namespace Sample2_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(new Waiting_to_SendState());

            order.Cancel();

            order.Send();
            order.Delivered();

            Console.Read();
        }
    }
}
