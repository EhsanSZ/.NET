using Grpc.Net.Client;
using grpcServer.Protos;
using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
           var channel=  GrpcChannel.ForAddress("https://localhost:5001/");
            var productClient = new ProductService.ProductServiceClient(channel);

           var response=  productClient.AddNewProduct(new RequestAddProductDTO
            {
                 Brand="Asus",
                 Name="NT100",
                 Price=1780000,
            });


            Console.WriteLine("IsSuccess" + response.IsSuccess);

            Console.ReadLine();
        }
    }
}
