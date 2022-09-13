using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Bugeto.Services;
using RazorPages.Services;

namespace RazorPage.Bugeto.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();

        private readonly IProductService _productService;
        public IndexModel(IProductService service)
        {
            _productService = service;
        }

        public void OnGet()
        {
            Products = _productService.List();
        }
    }
}
