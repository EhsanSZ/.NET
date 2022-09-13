
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;

namespace RazorPages.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]

        public ProductDto Product { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Product = _productService.Find(id.Value);
            return Page();
        }

        public IActionResult OnPost()
        {
            _productService.Edit(Product);
            return Page();
        }
    }
}
