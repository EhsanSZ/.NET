using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;

namespace RestClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello RestSharp!");

            var client = new RestClient("https://localhost:44379/");
            //get  sms Code
            var getSmsRequest = new RestRequest("/api/Accounts/GetSmsCode",Method.GET);
            getSmsRequest.AddParameter("PhoneNumber", "09128698172");
            var getSmsResult= client.Get(getSmsRequest);

            //send smsCode and Get Token

            ;
            var getTokenRequest = new RestRequest("/api/Accounts", Method.POST);
            getTokenRequest.AddJsonBody(new { PhoneNumber = "09128698172", SmsCode = "1957" });
            //var getTokenResult= client.Post(getTokenRequest);
            var getTokenResult= client.Post<LoginResultDto>(getTokenRequest);
            if(getTokenResult.Data.IsSuccess)
            {

             Console.WriteLine(" Token:"+ getTokenResult.Data.Data.Token);

                client.Authenticator = new JwtAuthenticator(getTokenResult.Data.Data.Token);
                var requestWithJwt = new RestRequest("/api/Categories");
                var categoryResult = client.Get<List<CategoryDto>>(requestWithJwt);
                foreach (var item in categoryResult.Data)
                {
                    Console.WriteLine(item.Name);
                }

            }

            ;
            Console.ReadLine();
        }
    }


    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class LoginResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public LoginDataDto Data { get; set; }
    }

    public class LoginDataDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

}
