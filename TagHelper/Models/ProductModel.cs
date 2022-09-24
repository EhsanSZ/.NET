using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelper.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [DisplayName("نام محصول")]
        public string Name { get; set; }
    }
}
