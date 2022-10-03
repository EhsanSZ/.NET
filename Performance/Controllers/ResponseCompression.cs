using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Performance.Controllers
{
    public class ResponseCompression : Controller
    {
        public List<string> Index()
        {
            List<string> model = new List<string>();

            for (int i = 0; i < 1000; i++)
            {
                model.Add($"data {i}");
            }

            return model;
        }
    }
}
