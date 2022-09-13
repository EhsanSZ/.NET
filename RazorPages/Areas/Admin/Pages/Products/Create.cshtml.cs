using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;

namespace RazorPages.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public ProductDto Product { get; set; } = new ProductDto();

        private readonly IProductService _productService;
        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }
       
        public void OnGet()
        {
        }

        public void OnPost()
        {
            _productService.Add(Product);
        }
    }
}
