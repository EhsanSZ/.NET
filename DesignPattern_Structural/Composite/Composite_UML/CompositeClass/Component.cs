using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_UML.CompositeClass
{
    public abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int Depth);
    }


    public class Composite : Component
    {
        private List<Component> _components = new List<Component>();
        public Composite(string name) : base(name)
        {
        }

        public Composite(string name, Component[] components) : base(name)
        {
            foreach (var item in components)
            {
                Add(item);
            }
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Display(int Depth)
        {
            Console.WriteLine(new string('-', Depth) + name);
            foreach (var item in _components)
            {
                item.Display(Depth + 2);
            }

        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display(int Depth)
        {
            Console.WriteLine(new string('-', Depth) + name);
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
