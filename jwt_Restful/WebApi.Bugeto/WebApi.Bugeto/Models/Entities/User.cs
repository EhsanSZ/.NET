using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Bugeto.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserToken> UserTokens {get;set;}
    }

 
    public class SmsCode
    {
        public int Id { get; set; }
        public string  PhoneNumber { get; set; }
        public string  Code{ get; set; }
        public bool Used { get; set; }
        public int RequestCount { get; set; }
        public DateTime InsertDate { get; set; }
    }

    public class UserToken
    {
        public int Id { get; set; }
        public string TokenHash { get; set; }
        public DateTime TokenExp { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExp { get; set; }

        public string MobileModel { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
