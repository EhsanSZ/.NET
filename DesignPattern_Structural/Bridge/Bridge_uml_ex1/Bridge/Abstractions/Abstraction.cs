using Bridge_uml_ex1.Bridge.Implementors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_uml_ex1.Bridge.Abstractions
{
    public abstract  class Abstraction
    {
        private Implementor implementor;
        public Abstraction()
        {
            implementor =new  ConcreateImplementor();
        }
        public virtual void Function()
        {
            implementor.Implementaion();
        }
    }


    public class RefinedAbstraction:Abstraction
    {

    }
}
