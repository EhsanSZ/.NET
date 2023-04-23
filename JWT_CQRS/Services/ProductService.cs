using AutoMapper;
using Infrastructure.Dto;
using Infrastructure.Models;
using Infrastructure.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class ProductService : IProductService
{
    private readonly OnlineShopDbContext dbContext;
    private readonly IMapper mapper;
    private readonly MyFileUtility fileUtility;
    private readonly ILogger<ProductService> logger;

    //repository ??
    //unit of work ??

    public ProductService(OnlineShopDbContext dbContext, IMapper mapper,
    MyFileUtility fileUtility, ILogger<ProductService> logger)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.fileUtility = fileUtility;
        this.logger = logger;
    }
    //DTO => Data Transfer Object
    public async Task<ProductDto> Add(ProductDto model)
    {
        logger.LogInformation("Call Add from ProductService");
        //file => FileStream

        //var product = mapper.Map<Product>(model);
        var product = new Product
        {
            Price = model.Price,
            ProductName = model.ProductName,
            //save in folder
            ThumbnailFileName = fileUtility.SaveFileInFolder(model.Thumbnail, nameof(Product), true),
            //db => byte[]
            Thumbnail = fileUtility.EncryptFile(fileUtility.ConvertToByteArray(model.Thumbnail)),
            ThumbnailFileExtenstion = fileUtility.GetFileExtension(model.Thumbnail.FileName),
            ThumbnailFileSize = model.Thumbnail.Length,
        };




        await dbContext.AddAsync(product);
        await dbContext.SaveChangesAsync();

        model.Id = product.Id;

        return model;
    }

    public async Task<ProductDto> Get(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        //var model = mapper.Map<ProductDto>(product);

        var model = new ProductDto
        {
            Id = product.Id,
            Price = product.Price,
            ProductName = product.ProductName,
            PriceWithComma = product.Price.ToString("###.###"),
            ThumbnailBase64 = fileUtility.ConvertToBase64(fileUtility.DecryptFile(product.Thumbnail)),
            //ThumbnailPath = "E:\\DevTube" => "localhost:1220/Media/Attachment/Product/654654654.txt"
            //ThumbnailUrl = fileUtility.GetFileUrl(product.ThumbnailFileName, nameof(Product)),
            ThumbnailUrl = fileUtility.GetEncryptedFileActionUrl(product.ThumbnailFileName, nameof(Product)),
        };
        return model;
    }

    public async Task<ShopActionResult<List<ProductDto>>> GetAll(int page = 1, int size = 3)
    {
        //    var result = await dbContext.Products.Select(product => new ProductDto{
        //        Id = product.Id,
        //         Price = product.Price,
        //         ProductName = product.ProductName,
        //         PriceWithComma = product.Price.ToString("###.###"),
        //    }).ToListAsync();

        logger.LogInformation("Call GetAll from ProductService");
        var result = new ShopActionResult<List<ProductDto>>();
        try
        {
            var products = await dbContext.Products
                    .Skip((page - 1) * size).Take(size)
                    .AsNoTracking()
                    .Select(q => new ProductDto
                    {
                        Id = q.Id,
                        Price = q.Price,
                        ProductName = q.ProductName,
                    })
                    .ToListAsync();

            var totalRecordCount = await dbContext.Products.CountAsync();

            result.IsSuccess = true;
            result.Data = products;
            result.Page = page;
            result.Size = size;
            result.Total = totalRecordCount;

            logger.LogInformation("GetAll from ProductService Success Call");

        }
        catch (Exception ex)
        {
            //1 => add exception info to Log file ???
            logger.LogError(ex.ToString());

            //2 => get error info in Responce
            result.IsSuccess = false;
            result.Message = ex.Message;
        }


        return result;
    }
}