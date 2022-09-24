using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelper.Models
{
    public class User
    {
        [Display(Name ="نام")]
        public string Name { get; set; }
        [Display(Name ="نام خانوادگی")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }
        public bool Gender { get; set; }
        [Range(15,120)]
        public byte Age { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        public Address Address { get; set; }

        [MinLength(10)]
        [MaxLength(100)]
        public string Description { get; set; }
    }

    public class Address
    {
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
    }
}
