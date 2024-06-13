using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Bugeto.Models.Contexts;
using WebApi.Bugeto.Models.Entities;

namespace WebApi.Bugeto.Models.Services
{
    public class UserRepository
    {
        private readonly DataBaseContext context;
        public UserRepository(DataBaseContext context)
        {
            this.context = context;
        }


        public User GetUser(Guid Id)
        {
            var user = context.Users.SingleOrDefault(p => p.Id == Id);
            return user;
        }

        public bool ValidateUser(string Username,string Password)
        {
            var user= context.Users.FirstOrDefault();
            return user != null ? true : false;
        }

        public string GetCode(string PhoneNumber)
        {
            Random random = new Random();
            string code = random.Next(1000, 9999).ToString();
            SmsCode smsCode = new SmsCode()
            {
                Code = code,
                InsertDate = DateTime.Now,
                PhoneNumber = PhoneNumber,
                RequestCount = 0,
                Used = false,
            };
            context.Add(smsCode);
            context.SaveChanges();

            return code;
        }

        public LoginDto Login(string phoneNumber,string  Code)
        {
            var smsCode = context.SmsCodes.Where(p => p.PhoneNumber == phoneNumber
              && p.Code == Code).FirstOrDefault();
            if(smsCode == null)
            {
                return new LoginDto
                {
                    IsSuccess = false,
                    Message = "کد وارد شده صحیح نیست!",

                };
            }
            else
            {
                if(smsCode.Used == true)
                {
                    return new LoginDto
                    {
                        IsSuccess = false,
                        Message = "کد وارد شده صحیح نیست!",

                    };
                }
                ////
                ///
                smsCode.RequestCount++;

                smsCode.Used = true;
                context.SaveChanges();
                var user = FindUserWithPhonenumber(phoneNumber);
                if(user != null)
                {
                    return new LoginDto
                    {
                        IsSuccess = true,
                        User = user,
                    };
                }
                else
                {
                    user = RegisterUser(phoneNumber);
                    return new LoginDto
                    {
                        IsSuccess = true,
                        User = user,
                    };
                }

            }

 

        }


        public User FindUserWithPhonenumber(string phoneNumber)
        {
            var user = context.Users.SingleOrDefault(p => p.PhoneNumber.Equals(phoneNumber));
            return user;
        }

        public User RegisterUser(string PhoneNumber)
        {
            User user = new User()
            {
                PhoneNumber = PhoneNumber,
                IsActive = true,
            };
            return user;
        }
        public void Logout(Guid userId)
        {
            var userToken = context.UserTokens.Where(p => p.UserId == userId).ToList();
            context.UserTokens.RemoveRange(userToken);
            context.SaveChanges();
        }

    }

    public class LoginDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
    }
}
