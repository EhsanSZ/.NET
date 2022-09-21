using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Security.Controllers
{
    public class SQLInjection : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //البته از پارامتر ها در استور پروسیجر میتونیم استفاده کنیم یا اینکه بیاییم لیست سفید یا لیست سیاه بسازیم
        [HttpPost]
        public IActionResult Index(string UserName, string Password)
        {
            List<string> blackList = new List<string>()
            {
                "--",
                "or",
                "=",
                "and",
                 ";",
                "/*",
                "*/",
                "@@",
                "@",
                "char",
                "nchar",
                "varchar",
                "nvarchar",
                "alter",
                "begin",
                "cast",
                "create",
                "cursor",
                "declare",
                "delete",
                "drop",
                "end",
                "exec",
                "execute",
                "fetch",
                "insert",
                "kill",
                "open",
                "select",
                "sys",
                "sysobjects",
                "syscolumns",
                "table",
                "update",
            };

            var passwordCheck = blackList.FirstOrDefault(p => Password.ToUpper().Contains(p.ToUpper()));
            if (passwordCheck != null)
            {
                ViewBag.Message = "احتمال هک شدن وجود دارد";
                return View();
            }

            var usernameCheck = blackList.FirstOrDefault(p => UserName.ToUpper().Contains(p.ToUpper()));
            if (usernameCheck != null)
            {
                ViewBag.Message = "احتمال هک شدن وجود دارد";
                return View();
            }


            SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=Sqlinject; Integrated Security=true");
            connection.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM Users WHERE UserName='{UserName}' AND Password='{Password}'", connection);

            var result = command.ExecuteReader();
            if (result.Read())
            {
                string name = result["UserName"].ToString();
                ViewBag.Message = $"سلام {name}  ورود شما با موفقیت انجام شد";
                return View();
            }
            else
            {
                ViewBag.Message = "ورود نا موفق";
                return View();
            }
        }
    }
}
