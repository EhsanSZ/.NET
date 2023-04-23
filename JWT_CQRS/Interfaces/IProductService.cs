using Infrastructure.Dto;
using Infrastructure.Models;

public interface IProductService
{
   // ??
    Task<ShopActionResult<List<ProductDto>>> GetAll(int page=1, int size=3);
    Task<ProductDto> Get(int id);
    Task<ProductDto> Add(ProductDto model);
}