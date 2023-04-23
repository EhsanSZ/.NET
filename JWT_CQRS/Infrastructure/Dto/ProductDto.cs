using Microsoft.AspNetCore.Http;

namespace Infrastructure.Dto;
public class ProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public long Price { get; set; }
    public string? PriceWithComma { get; set; }
    public IFormFile Thumbnail { get; set; }
    public string? ThumbnailBase64 { get; set; }
    public string? ThumbnailUrl { get; set; }
}