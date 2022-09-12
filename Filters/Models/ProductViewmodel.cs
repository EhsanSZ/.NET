using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Models
{
    public class ProductViewmodel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int price { get; set; }
    }
}
