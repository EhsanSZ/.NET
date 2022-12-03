using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu_Category_Sample.Models.Entities
{
    public abstract class CategoryComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string Print()
        {
            throw new NotSupportedException();
        }

        public abstract void Add(CategoryComponent menuComponent);
        public abstract void Remove(CategoryComponent menuComponent);

    }
    public class Category : CategoryComponent
    {
        readonly List<CategoryComponent> _menuComponents = new List<CategoryComponent>();
        public ICollection<CategoryComponent> MenuItems => _menuComponents;
        public Category(string name)
        {
            Name = name;
        }
        public Category()
        { }

        public override void Add(CategoryComponent menuComponent)
        {
            _menuComponents.Add(menuComponent);
        }

        public override void Remove(CategoryComponent menuComponent)
        {
            _menuComponents.Remove(menuComponent);
        }

        public override string Print()
        {
            string ul = @$"<ul> {Name}";
            foreach (var menuComponent in _menuComponents)
            {
                ul += menuComponent.Print();
            }
            ul += @$"</ul> ";
            return ul;
        }
    }
    public class CategoryItem : CategoryComponent
    {
        public string Link { get; set; }
        public CategoryItem(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public CategoryItem()
        { }

        public override string Print()
        {
            string li = @$"<li> <a href='{Link}'> { Name }  </a> </li>";
            return li;
        }

        public override void Add(CategoryComponent menuComponent)
        {
            throw new NotImplementedException();
        }

        public override void Remove(CategoryComponent menuComponent)
        {
            throw new NotImplementedException();
        }
    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryItem CategoryItem { get; set; }
        public int CategoryItemId { get; set; }
    }
 
}
