using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Services.ProductB
{
    public class ProductB1 : AbstractProductB
    {
        public void Execute()
        {
            Console.WriteLine("ProductB1");
        }
    }
}
