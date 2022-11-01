

using System.Collections.Generic;

namespace Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
