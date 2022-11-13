using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Sort
{
    public class Sort
    {
        public static void Sort_Example()
        {

            var dataOrderBy = GetCourselist().OrderBy(p => p.Price);

            Console.WriteLine("__________________OrderBy_______________________");

            foreach (var item in dataOrderBy)
            {
                Console.WriteLine($"Id = {item.Id}      Name = {item.Name}   Price = {item.Price}");
            }




            var ThenBy = GetCourselist().OrderBy(p => p.Price).ThenBy(p => p.Name);

            Console.WriteLine("__________________ThenBy_______________________");

            foreach (var item in ThenBy)
            {
                Console.WriteLine($"Id = {item.Id}      Name = {item.Name}   Price = {item.Price}");
            }





            var Descending = GetCourselist().OrderByDescending(p => p.Price);


            Console.WriteLine("__________________Descending_______________________");

            foreach (var item in Descending)
            {
                Console.WriteLine($"Id = {item.Id}      Name = {item.Name}   Price = {item.Price}");
            }



            var ThenByDescending = GetCourselist().OrderByDescending(p => p.Price).ThenByDescending(p => p.Id);


            Console.WriteLine("__________________ThenByDescending_______________________");

            foreach (var item in ThenByDescending)
            {
                Console.WriteLine($"Id = {item.Id}      Name = {item.Name}   Price = {item.Price}");
            }




            Console.WriteLine("__________________Reverse_______________________");

            foreach (var item in ThenByDescending.Reverse())
            {
                Console.WriteLine($"Id = {item.Id}      Name = {item.Name}   Price = {item.Price}");
            }


        }


        private static List<Course> GetCourselist()
        {
            List<Course> courses = new List<Course>()
            {
                 new Course { Id=1000, Name="Asp net core" , Price= 3500},
                 new Course { Id=1001, Name="MongoDb" , Price= 7100},
                 new Course { Id =1002, Name = "Android", Price = 3500 },
            };

            return courses;
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
