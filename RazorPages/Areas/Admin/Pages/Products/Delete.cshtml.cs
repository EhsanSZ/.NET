using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;

namespace RazorPage.Bugeto.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;
        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }
        [BindProperty]
        public ProductDto Product { get; set; }
 
        public IActionResult OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Product = _productService.Find(id.Value);

            return Page();
        }

       public IActionResult OnPost()
        {
            _productService.Delete(Product.Id);
            return RedirectToPage("index");
        }
    }
}
