using Redis.Models.Dto;
using System.Collections.Generic;
using System.Threading;

namespace Redis.Models
{
    public interface IProductRepository
    {
        HomePageDto GetHomePageProducts();
    }
    public class ProductRepository: IProductRepository
    {
        public HomePageDto GetHomePageProducts()
        {
            Thread.Sleep(3000);
            return new HomePageDto()
            {
                 BestProduct = new BestProduct()
                {
                    Products = new List<ProductDto>()
                      {
                           new ProductDto { Id=1, Name="آموزش اصول  Solid"},
                           new ProductDto { Id=2, Name="آموزش الگوهای طراحی"}
                      }
                },
                 LastProduct = new LastProduct()
                {
                    Products = new List<ProductDto>()
                      {
                           new ProductDto { Id=3, Name="آموزش میکروسرویس"},
                           new ProductDto { Id=4, Name="آموزش DDD"},
                           new ProductDto { Id=5, Name="آموزش پیشرفته سی شارپ"}
                      }
                }
            };
        }
    }
}
