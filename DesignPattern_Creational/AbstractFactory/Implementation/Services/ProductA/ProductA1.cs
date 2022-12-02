using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Services.ProductA
{
    public class ProductA1 : AbstractProductA
    {
        public void Execute()
        {
            Console.WriteLine("ProductA1");
        }
    }
}
