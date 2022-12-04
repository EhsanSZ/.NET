using System;
namespace Chain_of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckUserActiveUser checkUserActiveUser = new CheckUserActiveUser();
            CreateOrder createOrder = new CreateOrder();
            SendOrderToDriver sendOrderToDriver = new SendOrderToDriver();
            CheckTest checkTest = new CheckTest();

            checkUserActiveUser
                .SetSuccessor(checkTest)
                .SetSuccessor(createOrder)
                .SetSuccessor(sendOrderToDriver);


            checkUserActiveUser.Execute(new RequestContext
            {
                UserId = 1,
                Origin = new Point { Lat = 53.3636, Lng = 54.22 },
                Destination = new Point { Lat = 53.3636, Lng = 54.22 },
            });


            Console.Read();
        }
    }


    public class RequestContext
    {
        public int UserId { get; set; }
        public Point Origin { get; set; }
        public Point Destination { get; set; }

    }

    public class Point
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }



    public class ResponseContext
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public interface IHandler
    {
        IHandler SetSuccessor(IHandler handler);
        ResponseContext Execute(RequestContext requestContext);
    }

    public abstract class TakeATaxiHandler : IHandler
    {

        protected IHandler successor;

        public abstract ResponseContext Execute(RequestContext requestContext);

        public IHandler SetSuccessor(IHandler handler)
        {
            this.successor = handler;
            return successor;
        }
    }


    public class CreateOrder : TakeATaxiHandler
    {
        public override ResponseContext Execute(RequestContext requestContext)
        {
            bool orderCreated = true;
            if (orderCreated)
            {
                Console.WriteLine("Order Created.....");
                if (successor != null)
                {
                    return successor.Execute(requestContext);
                }
                else
                {
                    ///
                }
            }
            return new ResponseContext
            {
                IsSuccess = false,
                Message = "Error Order Created "
            };
        }
    }


    public class SendOrderToDriver : TakeATaxiHandler
    {
        public override ResponseContext Execute(RequestContext requestContext)
        {
            Console.WriteLine("Send tto Driver");
            if (successor != null)
            {
                return successor.Execute(requestContext);
            }

            return new ResponseContext
            {
                IsSuccess = true,
                Message = "Order Create and send to driver"
            };

        }
    }


    public class CheckUserActiveUser : TakeATaxiHandler
    {
        public override ResponseContext Execute(RequestContext requestContext)
        {
            if (requestContext.UserId != 1)
            {
                Console.WriteLine("User Not Active");
                return new ResponseContext
                {
                    IsSuccess = false,
                    Message = "User not Active"
                };
            }
            else if (successor != null)
            {
                Console.WriteLine("User Is Active");
                return successor.Execute(requestContext);
            }
            else
            {
                return new ResponseContext
                {
                    IsSuccess = false,
                    Message = "error"
                };
            }
        }
    }


    public class CheckTest : TakeATaxiHandler
    {
        public override ResponseContext Execute(RequestContext requestContext)
        {
            Console.WriteLine("Check Test is Done");

            if (successor != null)
            {
                return successor.Execute(requestContext);
            }

            return new ResponseContext
            {
                IsSuccess = false,
                Message = "error"
            };
        }
    }
}
