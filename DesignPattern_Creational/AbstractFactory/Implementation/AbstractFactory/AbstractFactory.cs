using AbstractFactory.Services.ProductA;
using AbstractFactory.Services.ProductB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.AbstractFactory
{
    public interface AbstractFactory
    {
        AbstractProductA CreateProductA();
        AbstractProductB CreateProductB();
    }
}
