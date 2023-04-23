using Grpc.Core;
using grpcServer.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpcServer.GRPC
{
    public class ProductWebService : ProductService.ProductServiceBase
    {
        static List<Products> Products = new List<Products>()
        {
             new Products { Brand="Benq" , Name="Monitor" , Price=78000},
        };

        public override Task<ResponseAddProduct> AddNewProduct(RequestAddProductDTO request, ServerCallContext context)
        {
            Products.Add(new GRPC.Products
            {
                Brand = request.Brand,
                Name = request.Name,
                Price = request.Price,
            });

            Console.WriteLine($"Name is : {request.Name}");
            Console.WriteLine($"Price is : {request.Price}");
            Console.WriteLine($"Brand is : {request.Brand}");

            return Task.FromResult(new ResponseAddProduct
            {
                IsSuccess = true
            });
        }

        public override Task<ResponseAllProduct> GetAllProduct(RequestAllProduct request, ServerCallContext context)
        {
           
            ResponseAllProduct response = new ResponseAllProduct();
            foreach (var item in Products)
            {
                response.Items.Add(new ProductItem
                {
                    Brand = item.Brand,
                    Name = item.Name,
                    Price = item.Price
                });
            }
            return Task.FromResult(response);
        }
    }


    public class Products
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
    }
}
