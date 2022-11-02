using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities2
{
 
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsRemoved { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
