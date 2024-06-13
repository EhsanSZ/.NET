using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Bugeto.Models.Contexts;
using WebApi.Bugeto.Models.Entities;

namespace WebApi.Bugeto.Models.Services
{
    public class CategoryRepository
    {
        private readonly DataBaseContext _context;
        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAll()
        {
           var data= _context.Categories.ToList()
               .Select(p => new CategoryDto
               {
                   Id = p.Id,
                   Name = p.Name
               }).ToList();

            return data;
        }
        public CategoryDto Find(int Id)
        {
            var category = _context.Categories.Find(Id);
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };

        }

        public int AddCategory(string Name)
        {
            Category category = new Category()
            {
                Name = Name
            };
            _context.Add(category);
             _context.SaveChanges();
            return category.Id;
        }
        public int Delete(int Id)
        {
            _context.Categories.Remove(new Category { Id = Id });
            return _context.SaveChanges();
        }

        public int Edit(CategoryDto categoryDto)
        {
            var category = _context.Categories.SingleOrDefault(p => p.Id == categoryDto.Id);
            category.Name = categoryDto.Name;
            return _context.SaveChanges();
        }
    }


    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
