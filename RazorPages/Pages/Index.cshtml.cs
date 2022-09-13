
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }     

        public void OnPostSendComment(int id)
        {

        }    
        public void OnPostSubscribe(int id)
        {

        }
         

        public void OnDelete()
        {

        }

        public void OnPut()
        {

        }

    }
}
