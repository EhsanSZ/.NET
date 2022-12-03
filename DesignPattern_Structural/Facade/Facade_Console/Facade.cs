using Facade_Console.SubSystem1;
using Facade_Console.SubSystem2;
using Facade_Console.SubSystem3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Console
{
    public class Facade
    {
        public void doSomething()
        {
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
            Class3 c3 = new Class3();

            c1.Action1();
            c2.Action2();
            c3.Action3();
            c1.Finish();
        }
    }
}
