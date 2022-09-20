using Microsoft.AspNetCore.Mvc;

namespace Security.Controllers
{
    public class Attacks : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OpenRediret(bool succeeded , string url)
        {
            //if(succeeded)
                //return LocalRedirect(url);

            if (Url.IsLocalUrl(url))
                return Redirect(url);
            else
            {
                // Logg
               return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CSRF(string name , string blog)
        {
            return View();
        }
    }
}
