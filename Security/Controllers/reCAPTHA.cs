using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Security.Controllers
{
    public class reCAPTHA : Controller
    {
        [HttpPost]
        public IActionResult Index(string UserName, string Password)
        {
            string googleResponse = HttpContext.Request.Form["g-Recaptcha-Response"];

            GoogleRecaptcha googleRecaptcha = new GoogleRecaptcha();
            if (googleRecaptcha.Verify(googleResponse) == false)
            {
                ViewBag.Message = "لطفا بر روی دکمه من ربات نیستم کلیک نمایید";

                return View();
            }

            return View();
        }
    }

    public class GoogleRecaptcha
    {
        public bool Verify(string googleResponse)
        {
            string sec = "6Ley---------------------------------ofu";
            HttpClient httpClient = new HttpClient();
            var result = httpClient.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={sec}&response={googleResponse}", null).Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            string content = result.Content.ReadAsStringAsync().Result;
            dynamic jsonData = JObject.Parse(content);

            if (jsonData.success == "true")
            {
                return true;
            }

            return false;
        }
    }
}
