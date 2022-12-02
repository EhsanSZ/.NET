using AbstractFactory.Services.ProductA;
using AbstractFactory.Services.ProductB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.AbstractFactory
{
    public class ConcreteFactory2 : AbstractFactory
    {
        public AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
}
