using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities3
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Timestamp]
        public byte[]  Timestamp { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public long CategoryId { get; set; }
    }

    public class Order
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class Pay
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
