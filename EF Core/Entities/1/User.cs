using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
